using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ML.Data;

namespace SaTeatar
{
    //public class PredstaveRatingData
    //{
        //input data class
        public class PredstaveRating
        {
            //Features
            [LoadColumn(0)]
            public int KupacId { get; set; }
            //Features
            [LoadColumn(1)]
            public int PredstavaId { get; set; }
            //Label
            [LoadColumn(2)]
            public int Label { get; set; } //?float
        }

        public class PredstaveRatingPrediction
        {
            public int Label; //?float
            public float Score;
        }
    //}
}
