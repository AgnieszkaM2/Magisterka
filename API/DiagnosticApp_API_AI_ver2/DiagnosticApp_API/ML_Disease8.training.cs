﻿// This file was auto-generated by ML.NET Model Builder.
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace DiagnosticApp_API
{
    public partial class ML_Disease8
    {
        public const string RetrainFilePath =  @"D:\Desktop\praca_magisterska\aplikacja\Magisterka\API\DiagnosticApp_API_AI_ver2\DiagnosticApp_API\DataSets\Zestaw7.csv";
        public const char RetrainSeparatorChar = ';';
        public const bool RetrainHasHeader =  true;

         /// <summary>
        /// Train a new model with the provided dataset.
        /// </summary>
        /// <param name="outputModelPath">File path for saving the model. Should be similar to "C:\YourPath\ModelName.mlnet"</param>
        /// <param name="inputDataFilePath">Path to the data file for training.</param>
        /// <param name="separatorChar">Separator character for delimited training file.</param>
        /// <param name="hasHeader">Boolean if training file has a header.</param>
        public static void Train(string outputModelPath, string inputDataFilePath = RetrainFilePath, char separatorChar = RetrainSeparatorChar, bool hasHeader = RetrainHasHeader)
        {
            var mlContext = new MLContext();

            var data = LoadIDataViewFromFile(mlContext, inputDataFilePath, separatorChar, hasHeader);
            var model = RetrainModel(mlContext, data);
            SaveModel(mlContext, model, data, outputModelPath);
        }

        /// <summary>
        /// Load an IDataView from a file path.
        /// </summary>
        /// <param name="mlContext">The common context for all ML.NET operations.</param>
        /// <param name="inputDataFilePath">Path to the data file for training.</param>
        /// <param name="separatorChar">Separator character for delimited training file.</param>
        /// <param name="hasHeader">Boolean if training file has a header.</param>
        /// <returns>IDataView with loaded training data.</returns>
        public static IDataView LoadIDataViewFromFile(MLContext mlContext, string inputDataFilePath, char separatorChar, bool hasHeader)
        {
            return mlContext.Data.LoadFromTextFile<ModelInput>(inputDataFilePath, separatorChar, hasHeader);
        }


        /// <summary>
        /// Save a model at the specified path.
        /// </summary>
        /// <param name="mlContext">The common context for all ML.NET operations.</param>
        /// <param name="model">Model to save.</param>
        /// <param name="data">IDataView used to train the model.</param>
        /// <param name="modelSavePath">File path for saving the model. Should be similar to "C:\YourPath\ModelName.mlnet.</param>
        public static void SaveModel(MLContext mlContext, ITransformer model, IDataView data, string modelSavePath)
        {
            // Pull the data schema from the IDataView used for training the model
            DataViewSchema dataViewSchema = data.Schema;

            using (var fs = File.Create(modelSavePath))
            {
                mlContext.Model.Save(model, dataViewSchema, fs);
            }
        }


        /// <summary>
        /// Retrain model using the pipeline generated as part of the training process.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainModel(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }

        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"sym1", @"sym1"),new InputOutputColumnPair(@"sym2", @"sym2"),new InputOutputColumnPair(@"sym3", @"sym3"),new InputOutputColumnPair(@"sym4", @"sym4"),new InputOutputColumnPair(@"sym5", @"sym5"),new InputOutputColumnPair(@"sym6", @"sym6"),new InputOutputColumnPair(@"sym7", @"sym7"),new InputOutputColumnPair(@"sym8", @"sym8"),new InputOutputColumnPair(@"sym9", @"sym9"),new InputOutputColumnPair(@"sym10", @"sym10"),new InputOutputColumnPair(@"sym11", @"sym11"),new InputOutputColumnPair(@"sym12", @"sym12"),new InputOutputColumnPair(@"sym13", @"sym13"),new InputOutputColumnPair(@"sym14", @"sym14"),new InputOutputColumnPair(@"sym15", @"sym15"),new InputOutputColumnPair(@"sym16", @"sym16"),new InputOutputColumnPair(@"sym17", @"sym17"),new InputOutputColumnPair(@"sym18", @"sym18"),new InputOutputColumnPair(@"sym19", @"sym19"),new InputOutputColumnPair(@"sym20", @"sym20"),new InputOutputColumnPair(@"sym21", @"sym21"),new InputOutputColumnPair(@"sym22", @"sym22"),new InputOutputColumnPair(@"sym23", @"sym23"),new InputOutputColumnPair(@"sym24", @"sym24"),new InputOutputColumnPair(@"sym25", @"sym25"),new InputOutputColumnPair(@"sym26", @"sym26"),new InputOutputColumnPair(@"sym27", @"sym27"),new InputOutputColumnPair(@"sym28", @"sym28"),new InputOutputColumnPair(@"sym29", @"sym29"),new InputOutputColumnPair(@"sym30", @"sym30"),new InputOutputColumnPair(@"sym31", @"sym31"),new InputOutputColumnPair(@"sym32", @"sym32"),new InputOutputColumnPair(@"sym33", @"sym33"),new InputOutputColumnPair(@"sym34", @"sym34"),new InputOutputColumnPair(@"sym35", @"sym35"),new InputOutputColumnPair(@"sym36", @"sym36"),new InputOutputColumnPair(@"sym37", @"sym37"),new InputOutputColumnPair(@"sym38", @"sym38"),new InputOutputColumnPair(@"sym39", @"sym39"),new InputOutputColumnPair(@"sym40", @"sym40"),new InputOutputColumnPair(@"sym41", @"sym41"),new InputOutputColumnPair(@"sym42", @"sym42"),new InputOutputColumnPair(@"sym43", @"sym43"),new InputOutputColumnPair(@"sym44", @"sym44"),new InputOutputColumnPair(@"sym45", @"sym45"),new InputOutputColumnPair(@"sym46", @"sym46"),new InputOutputColumnPair(@"sym47", @"sym47"),new InputOutputColumnPair(@"sym48", @"sym48"),new InputOutputColumnPair(@"sym49", @"sym49"),new InputOutputColumnPair(@"sym50", @"sym50"),new InputOutputColumnPair(@"sym51", @"sym51"),new InputOutputColumnPair(@"sym52", @"sym52"),new InputOutputColumnPair(@"sym53", @"sym53"),new InputOutputColumnPair(@"sym54", @"sym54"),new InputOutputColumnPair(@"sym55", @"sym55"),new InputOutputColumnPair(@"sym56", @"sym56"),new InputOutputColumnPair(@"sym57", @"sym57"),new InputOutputColumnPair(@"sym58", @"sym58"),new InputOutputColumnPair(@"sym59", @"sym59"),new InputOutputColumnPair(@"sym60", @"sym60"),new InputOutputColumnPair(@"sym61", @"sym61"),new InputOutputColumnPair(@"sym62", @"sym62"),new InputOutputColumnPair(@"sym63", @"sym63"),new InputOutputColumnPair(@"sym64", @"sym64"),new InputOutputColumnPair(@"sym65", @"sym65"),new InputOutputColumnPair(@"sym66", @"sym66"),new InputOutputColumnPair(@"sym67", @"sym67"),new InputOutputColumnPair(@"sym68", @"sym68"),new InputOutputColumnPair(@"sym69", @"sym69"),new InputOutputColumnPair(@"sym70", @"sym70"),new InputOutputColumnPair(@"sym71", @"sym71"),new InputOutputColumnPair(@"sym72", @"sym72"),new InputOutputColumnPair(@"sym73", @"sym73"),new InputOutputColumnPair(@"sym74", @"sym74"),new InputOutputColumnPair(@"sym75", @"sym75"),new InputOutputColumnPair(@"sym76", @"sym76"),new InputOutputColumnPair(@"sym77", @"sym77"),new InputOutputColumnPair(@"sym78", @"sym78"),new InputOutputColumnPair(@"sym79", @"sym79"),new InputOutputColumnPair(@"sym80", @"sym80"),new InputOutputColumnPair(@"sym81", @"sym81"),new InputOutputColumnPair(@"sym82", @"sym82"),new InputOutputColumnPair(@"sym83", @"sym83"),new InputOutputColumnPair(@"sym84", @"sym84"),new InputOutputColumnPair(@"sym85", @"sym85"),new InputOutputColumnPair(@"sym86", @"sym86"),new InputOutputColumnPair(@"sym87", @"sym87"),new InputOutputColumnPair(@"sym88", @"sym88"),new InputOutputColumnPair(@"sym89", @"sym89"),new InputOutputColumnPair(@"sym90", @"sym90"),new InputOutputColumnPair(@"sym91", @"sym91"),new InputOutputColumnPair(@"sym92", @"sym92"),new InputOutputColumnPair(@"sym93", @"sym93"),new InputOutputColumnPair(@"sym94", @"sym94"),new InputOutputColumnPair(@"sym95", @"sym95"),new InputOutputColumnPair(@"sym96", @"sym96"),new InputOutputColumnPair(@"sym97", @"sym97"),new InputOutputColumnPair(@"sym98", @"sym98"),new InputOutputColumnPair(@"sym99", @"sym99"),new InputOutputColumnPair(@"sym100", @"sym100"),new InputOutputColumnPair(@"sym101", @"sym101"),new InputOutputColumnPair(@"sym102", @"sym102"),new InputOutputColumnPair(@"sym103", @"sym103"),new InputOutputColumnPair(@"sym104", @"sym104"),new InputOutputColumnPair(@"sym105", @"sym105"),new InputOutputColumnPair(@"sym106", @"sym106"),new InputOutputColumnPair(@"sym107", @"sym107"),new InputOutputColumnPair(@"sym108", @"sym108"),new InputOutputColumnPair(@"sym109", @"sym109"),new InputOutputColumnPair(@"sym110", @"sym110"),new InputOutputColumnPair(@"sym111", @"sym111"),new InputOutputColumnPair(@"sym112", @"sym112"),new InputOutputColumnPair(@"sym113", @"sym113"),new InputOutputColumnPair(@"sym114", @"sym114"),new InputOutputColumnPair(@"sym115", @"sym115"),new InputOutputColumnPair(@"sym116", @"sym116"),new InputOutputColumnPair(@"sym117", @"sym117"),new InputOutputColumnPair(@"sym118", @"sym118"),new InputOutputColumnPair(@"sym119", @"sym119"),new InputOutputColumnPair(@"sym120", @"sym120"),new InputOutputColumnPair(@"sym121", @"sym121"),new InputOutputColumnPair(@"sym122", @"sym122"),new InputOutputColumnPair(@"sym123", @"sym123"),new InputOutputColumnPair(@"sym124", @"sym124"),new InputOutputColumnPair(@"sym125", @"sym125"),new InputOutputColumnPair(@"sym126", @"sym126"),new InputOutputColumnPair(@"sym127", @"sym127"),new InputOutputColumnPair(@"sym128", @"sym128"),new InputOutputColumnPair(@"sym129", @"sym129"),new InputOutputColumnPair(@"sym130", @"sym130"),new InputOutputColumnPair(@"sym131", @"sym131"),new InputOutputColumnPair(@"sym132", @"sym132"),new InputOutputColumnPair(@"sym133", @"sym133"),new InputOutputColumnPair(@"sym134", @"sym134"),new InputOutputColumnPair(@"sym135", @"sym135"),new InputOutputColumnPair(@"sym136", @"sym136"),new InputOutputColumnPair(@"sym137", @"sym137"),new InputOutputColumnPair(@"sym138", @"sym138"),new InputOutputColumnPair(@"sym139", @"sym139"),new InputOutputColumnPair(@"sym140", @"sym140"),new InputOutputColumnPair(@"sym141", @"sym141"),new InputOutputColumnPair(@"sym142", @"sym142"),new InputOutputColumnPair(@"sym143", @"sym143"),new InputOutputColumnPair(@"sym144", @"sym144"),new InputOutputColumnPair(@"sym145", @"sym145"),new InputOutputColumnPair(@"sym146", @"sym146"),new InputOutputColumnPair(@"sym147", @"sym147"),new InputOutputColumnPair(@"sym148", @"sym148"),new InputOutputColumnPair(@"sym149", @"sym149"),new InputOutputColumnPair(@"sym150", @"sym150"),new InputOutputColumnPair(@"sym151", @"sym151"),new InputOutputColumnPair(@"sym152", @"sym152"),new InputOutputColumnPair(@"sym153", @"sym153"),new InputOutputColumnPair(@"sym154", @"sym154"),new InputOutputColumnPair(@"sym155", @"sym155"),new InputOutputColumnPair(@"sym156", @"sym156"),new InputOutputColumnPair(@"sym157", @"sym157"),new InputOutputColumnPair(@"sym158", @"sym158"),new InputOutputColumnPair(@"sym159", @"sym159"),new InputOutputColumnPair(@"sym160", @"sym160"),new InputOutputColumnPair(@"sym161", @"sym161"),new InputOutputColumnPair(@"sym162", @"sym162"),new InputOutputColumnPair(@"sym163", @"sym163"),new InputOutputColumnPair(@"sym164", @"sym164"),new InputOutputColumnPair(@"sym165", @"sym165"),new InputOutputColumnPair(@"sym166", @"sym166"),new InputOutputColumnPair(@"sym167", @"sym167"),new InputOutputColumnPair(@"sym168", @"sym168"),new InputOutputColumnPair(@"sym169", @"sym169"),new InputOutputColumnPair(@"sym170", @"sym170"),new InputOutputColumnPair(@"sym171", @"sym171"),new InputOutputColumnPair(@"sym172", @"sym172"),new InputOutputColumnPair(@"sym173", @"sym173"),new InputOutputColumnPair(@"sym174", @"sym174"),new InputOutputColumnPair(@"sym175", @"sym175"),new InputOutputColumnPair(@"sym176", @"sym176"),new InputOutputColumnPair(@"sym177", @"sym177"),new InputOutputColumnPair(@"sym178", @"sym178"),new InputOutputColumnPair(@"sym179", @"sym179"),new InputOutputColumnPair(@"sym180", @"sym180"),new InputOutputColumnPair(@"sym181", @"sym181"),new InputOutputColumnPair(@"sym182", @"sym182"),new InputOutputColumnPair(@"sym183", @"sym183"),new InputOutputColumnPair(@"sym184", @"sym184"),new InputOutputColumnPair(@"sym185", @"sym185"),new InputOutputColumnPair(@"sym186", @"sym186"),new InputOutputColumnPair(@"sym187", @"sym187"),new InputOutputColumnPair(@"sym188", @"sym188"),new InputOutputColumnPair(@"sym189", @"sym189"),new InputOutputColumnPair(@"sym190", @"sym190"),new InputOutputColumnPair(@"sym191", @"sym191"),new InputOutputColumnPair(@"sym192", @"sym192"),new InputOutputColumnPair(@"sym193", @"sym193"),new InputOutputColumnPair(@"sym194", @"sym194"),new InputOutputColumnPair(@"sym195", @"sym195"),new InputOutputColumnPair(@"sym196", @"sym196"),new InputOutputColumnPair(@"sym197", @"sym197"),new InputOutputColumnPair(@"sym198", @"sym198"),new InputOutputColumnPair(@"sym199", @"sym199"),new InputOutputColumnPair(@"sym200", @"sym200"),new InputOutputColumnPair(@"sym201", @"sym201"),new InputOutputColumnPair(@"sym202", @"sym202"),new InputOutputColumnPair(@"sym203", @"sym203"),new InputOutputColumnPair(@"sym204", @"sym204"),new InputOutputColumnPair(@"sym205", @"sym205"),new InputOutputColumnPair(@"sym206", @"sym206"),new InputOutputColumnPair(@"sym207", @"sym207"),new InputOutputColumnPair(@"sym208", @"sym208"),new InputOutputColumnPair(@"sym209", @"sym209"),new InputOutputColumnPair(@"sym210", @"sym210"),new InputOutputColumnPair(@"sym211", @"sym211"),new InputOutputColumnPair(@"sym212", @"sym212"),new InputOutputColumnPair(@"sym213", @"sym213"),new InputOutputColumnPair(@"sym214", @"sym214"),new InputOutputColumnPair(@"sym215", @"sym215"),new InputOutputColumnPair(@"sym216", @"sym216"),new InputOutputColumnPair(@"sym217", @"sym217"),new InputOutputColumnPair(@"sym218", @"sym218"),new InputOutputColumnPair(@"sym219", @"sym219"),new InputOutputColumnPair(@"sym220", @"sym220"),new InputOutputColumnPair(@"sym221", @"sym221"),new InputOutputColumnPair(@"sym222", @"sym222"),new InputOutputColumnPair(@"sym223", @"sym223"),new InputOutputColumnPair(@"sym224", @"sym224"),new InputOutputColumnPair(@"sym225", @"sym225"),new InputOutputColumnPair(@"sym226", @"sym226")})      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"sym1",@"sym2",@"sym3",@"sym4",@"sym5",@"sym6",@"sym7",@"sym8",@"sym9",@"sym10",@"sym11",@"sym12",@"sym13",@"sym14",@"sym15",@"sym16",@"sym17",@"sym18",@"sym19",@"sym20",@"sym21",@"sym22",@"sym23",@"sym24",@"sym25",@"sym26",@"sym27",@"sym28",@"sym29",@"sym30",@"sym31",@"sym32",@"sym33",@"sym34",@"sym35",@"sym36",@"sym37",@"sym38",@"sym39",@"sym40",@"sym41",@"sym42",@"sym43",@"sym44",@"sym45",@"sym46",@"sym47",@"sym48",@"sym49",@"sym50",@"sym51",@"sym52",@"sym53",@"sym54",@"sym55",@"sym56",@"sym57",@"sym58",@"sym59",@"sym60",@"sym61",@"sym62",@"sym63",@"sym64",@"sym65",@"sym66",@"sym67",@"sym68",@"sym69",@"sym70",@"sym71",@"sym72",@"sym73",@"sym74",@"sym75",@"sym76",@"sym77",@"sym78",@"sym79",@"sym80",@"sym81",@"sym82",@"sym83",@"sym84",@"sym85",@"sym86",@"sym87",@"sym88",@"sym89",@"sym90",@"sym91",@"sym92",@"sym93",@"sym94",@"sym95",@"sym96",@"sym97",@"sym98",@"sym99",@"sym100",@"sym101",@"sym102",@"sym103",@"sym104",@"sym105",@"sym106",@"sym107",@"sym108",@"sym109",@"sym110",@"sym111",@"sym112",@"sym113",@"sym114",@"sym115",@"sym116",@"sym117",@"sym118",@"sym119",@"sym120",@"sym121",@"sym122",@"sym123",@"sym124",@"sym125",@"sym126",@"sym127",@"sym128",@"sym129",@"sym130",@"sym131",@"sym132",@"sym133",@"sym134",@"sym135",@"sym136",@"sym137",@"sym138",@"sym139",@"sym140",@"sym141",@"sym142",@"sym143",@"sym144",@"sym145",@"sym146",@"sym147",@"sym148",@"sym149",@"sym150",@"sym151",@"sym152",@"sym153",@"sym154",@"sym155",@"sym156",@"sym157",@"sym158",@"sym159",@"sym160",@"sym161",@"sym162",@"sym163",@"sym164",@"sym165",@"sym166",@"sym167",@"sym168",@"sym169",@"sym170",@"sym171",@"sym172",@"sym173",@"sym174",@"sym175",@"sym176",@"sym177",@"sym178",@"sym179",@"sym180",@"sym181",@"sym182",@"sym183",@"sym184",@"sym185",@"sym186",@"sym187",@"sym188",@"sym189",@"sym190",@"sym191",@"sym192",@"sym193",@"sym194",@"sym195",@"sym196",@"sym197",@"sym198",@"sym199",@"sym200",@"sym201",@"sym202",@"sym203",@"sym204",@"sym205",@"sym206",@"sym207",@"sym208",@"sym209",@"sym210",@"sym211",@"sym212",@"sym213",@"sym214",@"sym215",@"sym216",@"sym217",@"sym218",@"sym219",@"sym220",@"sym221",@"sym222",@"sym223",@"sym224",@"sym225",@"sym226"}))      
                                    .Append(mlContext.Regression.Trainers.Sdca(new SdcaRegressionTrainer.Options(){L1Regularization=0.06351439F,L2Regularization=0.07420357F,LabelColumnName=@"D8",FeatureColumnName=@"Features"}));

            return pipeline;
        }
    }
 }
