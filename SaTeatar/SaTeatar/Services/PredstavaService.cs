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

namespace SaTeatar.WebAPI.Services
{
    public class PredstavaService : BaseCRUDService<mPredstave, Predstave, rPredstavaSearch, rPredstavaInsert, rPredstavaUpdate>
        , IPredstavaService
    {
        public PredstavaService(SaTeatarDbContext context, IMapper mapper)
            : base(context, mapper)
        {

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

            var entities = query.ToList();

            var result = _mapper.Map<IList<mPredstave>>(entities);

            return result;
        }

        public void RecommenderPokusaj()
        {
            MLContext mLContext = new MLContext();

            (IDataView trainingDataView, IDataView testDataView) = LoadData(mLContext);

            ITransformer model = BuildAndTrainModel(mLContext, trainingDataView);

            EvaluateModel(mLContext, testDataView, model);

            UseModelForSinglePrediction(mLContext, model);

            SaveModel(mLContext, trainingDataView.Schema, model);


            /*public*/
            static (IDataView training, IDataView test) LoadData(MLContext mlContext)
            {
                var trainingDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "recommendation-ratings-train.csv");
                var testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "recommendation-ratings-test.csv");

                IDataView trainingDataView = mlContext.Data.LoadFromTextFile<PredstaveRating>(trainingDataPath, hasHeader: true, separatorChar: ',');
                IDataView testDataView = mlContext.Data.LoadFromTextFile<PredstaveRating>(testDataPath, hasHeader: true, separatorChar: ',');

                return (trainingDataView, testDataView);
            }

            /*public*/
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

            /*public*/
            static void EvaluateModel(MLContext mlContext, IDataView testDataView, ITransformer model)
            {
                Console.WriteLine("=============== Evaluating the model ===============");
                var prediction = model.Transform(testDataView);

                var metrics = mlContext.Regression.Evaluate(prediction, labelColumnName: "Label", scoreColumnName: "Score");

                Console.WriteLine("Root Mean Squared Error : " + metrics.RootMeanSquaredError.ToString());
                Console.WriteLine("RSquared: " + metrics.RSquared.ToString());

            }

            /*public*/ static void UseModelForSinglePrediction(MLContext mlContext, ITransformer model)
            {
                Console.WriteLine("=============== Making a prediction ===============");
                var predictionEngine = mlContext.Model.CreatePredictionEngine<PredstaveRating, PredstaveRatingPrediction>(model);

                var testInput = new PredstaveRating { KupacId = 6, PredstavaId = 10 };

                var movieRatingPrediction = predictionEngine.Predict(testInput);

                if (Math.Round(movieRatingPrediction.Score, 1) > 3.5)
                {
                    Console.WriteLine("Movie " + testInput.PredstavaId + " is recommended for user " + testInput.KupacId);
                }
                else
                {
                    Console.WriteLine("Movie " + testInput.PredstavaId + " is not recommended for user " + testInput.KupacId);
                }
            }

            /*public*/ static void SaveModel(MLContext mlContext, DataViewSchema trainingDataViewSchema, ITransformer model)
            {
                var modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "PredstaveRecommenderModel.zip");

                Console.WriteLine("=============== Saving the model to a file ===============");
                mlContext.Model.Save(model, trainingDataViewSchema, modelPath);
            }
        }
    }
}

