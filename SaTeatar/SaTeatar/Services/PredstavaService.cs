using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SaTeatar.Model.Models;
using SaTeatar.Model.Requests;
using SaTeatar.Database;
using Microsoft.ML;
using System.IO;
using Microsoft.ML.Trainers;
using Microsoft.EntityFrameworkCore;
using Microsoft.ML.Data;
using Microsoft.Data.SqlClient;

namespace SaTeatar.WebAPI.Services
{
    public class PredstavaService : BaseCRUDService<mPredstave, Predstave, rPredstavaSearch, rPredstavaInsert, rPredstavaUpdate>
        , IPredstavaService
    {
        public PredstavaService(SaTeatarBpContext context, IMapper mapper)
            : base(context, mapper)
        {

        }

        //navela sam user based collaborative u prijavi, nismo to radili na nastavi pa sam pokusala napraviti
        //po ovom tutorialu https://docs.microsoft.com/en-us/dotnet/machine-learning/tutorials/movie-recommendation
        //git https://github.com/dotnet/samples/tree/main/machine-learning/tutorials/MovieRecommendation
        public List<mPredstave> Recommend(int KupacId)
        {
            // pokusaj sa podacima direktno iz baze
            // nemam testdata, niti sam radila evoluaciju modela

            MLContext mLContext = new MLContext();

            var ocjene = _context.Ocjene.ToList();
            // treba lista predstava koje nije gledao, ne sve
            var karteIzvodjenja = _context.Karte.Include(y => y.Izvodjenje).Where(x => x.KupacId == KupacId).Select(x => x.Izvodjenje.PredstavaId).ToList();
            var pregledanePredstaveIds = karteIzvodjenja.Distinct().ToList();
            var sveAktivnePredstave = _context.Predstave.Where(x => x.Status == true).AsQueryable();
            var sveAktivnePredstaveIds = sveAktivnePredstave.Select(x => x.PredstavaId).ToList();
            var nepregledanePredstaveIds = sveAktivnePredstaveIds.Except(pregledanePredstaveIds).ToList();

            var predstave = new List<Predstave>();

            foreach (var p in sveAktivnePredstave)
            {
                foreach (var id in nepregledanePredstaveIds)
                {
                    if (id==p.PredstavaId)
                    {
                        predstave.Add(new Predstave()
                        {
                            PredstavaId = p.PredstavaId,
                            Naziv = p.Naziv,
                            Opis = p.Opis,
                            Slika = p.Slika,
                            Status = p.Status,
                            TipPredstaveId = p.TipPredstaveId
                        });
                    }
                }

            }

           // DatabaseLoader loader = mLContext.Data.CreateDatabaseLoader<PredstaveRating>();

            //string connectionString = @"Data Source = localhost; Initial Catalog = SaTeatarSaSeedom; Integrated Security = True;";

            //string sqlCommand = "SELECT KupacId, PredstavaId, Ocjena FROM House";

            //DatabaseSource dbSource = new DatabaseSource(SqlClientFactory.Instance, connectionString, sqlCommand);

            //IDataView traindata = loader.Load(dbSource);

            var data = new List<PredstaveRating>();

            foreach (var o in ocjene)
            {
                data.Add(new PredstaveRating() { KupacId = o.KupacId, PredstavaId = o.PredstavaId, Label = o.Ocjena });
            }

            IDataView traindata = mLContext.Data.LoadFromEnumerable(data);

            ITransformer model = BuildAndTrainModel(mLContext, traindata);

            var preporucenePredstave = UseModelForPrediction(mLContext, model, KupacId, predstave);

            return _mapper.Map<List<mPredstave>>(preporucenePredstave);

        }

        List<Predstave> UseModelForPrediction(MLContext mlContext, ITransformer model, int KupacId, List<Predstave> predstave)
        {
            Console.WriteLine("=============== Making a prediction ===============");
            var predictionEngine = mlContext.Model.CreatePredictionEngine<PredstaveRating, PredstaveRatingPrediction>(model);

            var preporucenePredstave = new List<Predstave>();

            foreach (var p in predstave)
            {
                var testInput = new PredstaveRating { KupacId = KupacId, PredstavaId = p.PredstavaId };
                var predstaveRatingPrediction = predictionEngine.Predict(testInput);

                if (Math.Round(predstaveRatingPrediction.Score, 1) > 3.5)
                {
                    preporucenePredstave.Add(new Predstave()
                    {
                        PredstavaId = p.PredstavaId,
                        Naziv = p.Naziv,
                        Opis = p.Opis,
                        Slika = p.Slika,
                        Status = p.Status,
                        TipPredstaveId = p.TipPredstaveId
                    });
                }
            }
            return preporucenePredstave;
        }

        //ovo ispod je sa csv fajlovima kako je navedeno u tutorialu.. nek stoji za svaki slucaj

        public List<mPredstave> RecommenderSaCSVfajlovima(int KupacId)
        {
            MLContext mLContext = new MLContext();

            (IDataView trainingDataView, IDataView testDataView) = LoadData(mLContext);

            ITransformer model = BuildAndTrainModel(mLContext, trainingDataView);

            EvaluateModel(mLContext, testDataView, model);

            ///
            var karteIzvodjenja = _context.Karte.Include(y => y.Izvodjenje).Where(x => x.KupacId == KupacId).Select(x => x.Izvodjenje.PredstavaId).ToList();
            var pregledanePredstaveIds = karteIzvodjenja.Distinct().ToList();
            var sveAktivnePredstave = _context.Predstave.Where(x => x.Status == true).AsQueryable();
            var sveAktivnePredstaveIds = sveAktivnePredstave.Select(x => x.PredstavaId).ToList();
            var nepregledanePredstaveIds = sveAktivnePredstaveIds.Except(pregledanePredstaveIds).ToList();

            var predstave = new List<Predstave>();

            foreach (var p in sveAktivnePredstave)
            {
                foreach (var id in nepregledanePredstaveIds)
                {
                    if (id == p.PredstavaId)
                    {
                        predstave.Add(new Predstave()
                        {
                            PredstavaId = p.PredstavaId,
                            Naziv = p.Naziv,
                            Opis = p.Opis,
                            Slika = p.Slika,
                            Status = p.Status,
                            TipPredstaveId = p.TipPredstaveId
                        });
                    }
                }

            }

            var preporucenePredstave = UseModelForPrediction(mLContext, model, KupacId, predstave);


            ///

            UseModelForSinglePrediction(mLContext, model);

            SaveModel(mLContext, trainingDataView.Schema, model);

            return _mapper.Map<List<mPredstave>>(preporucenePredstave);
        }

        static (IDataView training, IDataView test) LoadData(MLContext mlContext)
        {
            var trainingDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "recommendation-ratings-train.csv");
            var testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "recommendation-ratings-test.csv");

            IDataView trainingDataView = mlContext.Data.LoadFromTextFile<PredstaveRating>(trainingDataPath, hasHeader: true, separatorChar: ',');
            IDataView testDataView = mlContext.Data.LoadFromTextFile<PredstaveRating>(testDataPath, hasHeader: true, separatorChar: ',');

            return (trainingDataView, testDataView);
        }

        static ITransformer BuildAndTrainModel(MLContext mlContext, IDataView trainingDataView)
        {
            IEstimator<ITransformer> estimator = mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "KupacIdEncoded", inputColumnName: "KupacId")
            .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName: "PredstavaIdEncoded", inputColumnName: "PredstavaId"));

            var options = new MatrixFactorizationTrainer.Options
            {
                MatrixColumnIndexColumnName = "KupacIdEncoded",
                MatrixRowIndexColumnName = "PredstavaIdEncoded",
                LabelColumnName = "Label",
                NumberOfIterations = 20,
                ApproximationRank = 100
            };

            var trainerEstimator = estimator.Append(mlContext.Recommendation().Trainers.MatrixFactorization(options));
            Console.WriteLine("=============== Training the model ===============");
            ITransformer model = trainerEstimator.Fit(trainingDataView);

            return model;
        }

        static void EvaluateModel(MLContext mlContext, IDataView testDataView, ITransformer model)
        {
            Console.WriteLine("=============== Evaluating the model ===============");
            var prediction = model.Transform(testDataView);

            var metrics = mlContext.Regression.Evaluate(prediction, labelColumnName: "Label", scoreColumnName: "Score");

            Console.WriteLine("Root Mean Squared Error : " + metrics.RootMeanSquaredError.ToString());
            Console.WriteLine("RSquared: " + metrics.RSquared.ToString());

        }

        static void UseModelForSinglePrediction(MLContext mlContext, ITransformer model)
        {
            Console.WriteLine("=============== Making a prediction ===============");
            var predictionEngine = mlContext.Model.CreatePredictionEngine<PredstaveRating, PredstaveRatingPrediction>(model);

            var testInput = new PredstaveRating { KupacId = 6, PredstavaId = 10 };

            var predstaveRatingPrediction = predictionEngine.Predict(testInput);

            if (Math.Round(predstaveRatingPrediction.Score, 1) > 3.5)
            {
                Console.WriteLine("Movie " + testInput.PredstavaId + " is recommended for user " + testInput.KupacId);
            }
            else
            {
                Console.WriteLine("Movie " + testInput.PredstavaId + " is not recommended for user " + testInput.KupacId);
            }
        }

        static void SaveModel(MLContext mlContext, DataViewSchema trainingDataViewSchema, ITransformer model)
        {
            var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "PredstaveRecommenderModel.zip");

            Console.WriteLine("=============== Saving the model to a file ===============");
            mlContext.Model.Save(model, trainingDataViewSchema, modelPath);
        }
        public override IList<mPredstave> Get(rPredstavaSearch search)
        {
            var query = _context.Predstave.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search?.Naziv))
            {
                query = query.Where(x => x.Naziv.Contains(search.Naziv));
            }

            if (search?.TipPredstaveId != 0)
            {
                query = query.Where(x => x.TipPredstaveId == search.TipPredstaveId);

            }
            if (search.Status==true)
            {
                query = query.Where(x => x.Status == search.Status);

            }

            var entities = query.ToList();

            var result = _mapper.Map<IList<mPredstave>>(entities);

            return result;
        }
    }
}

