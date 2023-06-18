using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace DiagnosticApp_API.System2
{
    public class AIDiagnosticSystem
    {
        public static List<FinalResults> Diagnose(int[] userInput)
        {
            List<FinalResults> finalResults = new List<FinalResults>();
            int[] weights = new int[] { 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 3, 1, 1, 2, 5, 1, 1, 3, 3, 5, 5, 3, 1, 3, 3, 3, 5, 5, 1, 5, 3, 3, 5, 2, 1, 3, 2, 1, 5, 5, 3, 1, 3, 3, 5, 3, 2, 3, 5, 5, 3, 3, 3, 1, 1, 1, 1, 5, 1, 1, 3, 3, 1, 1, 2, 2, 5, 2, 2, 3, 3, 2, 5, 3, 5, 5, 1, 2, 1, 5, 3, 3, 3, 5, 5, 2, 3, 3, 3, 3, 3, 3, 5, 3, 5, 3, 5, 3, 3, 3, 3, 3, 3, 2, 2, 5, 3, 3, 3, 3, 3, 1, 3, 3, 3, 5, 1, 2, 1, 5, 3, 3, 5, 3, 3, 3, 3, 3, 3, 3, 5, 5, 5, 3, 5, 3, 3, 2, 5, 5, 3, 3, 3, 3, 5, 5, 3, 3, 5, 3, 2, 3, 3, 3, 5, 3, 5, 3, 3, 3, 3, 3, 5, 1, 3, 3, 2, 3, 3, 3, 5, 3, 3, 3, 5, 3, 5, 2, 3, 3, 3, 3, 3, 5, 5, 3, 5, 5, 5, 3, 5, 2, 2, 3, 5, 5, 3, 5, 5, 5, 3, 5, 3, 5, 3, 3, 3, 3, 5, 3, 3, 3, 3, 5, 3, 5, 3, 5, 5, 3, 3, 3, 3, 3, 5, 5 };
            var predictionData = new MLModel1.ModelInput();
            Type diseaseType = typeof(MLModel1.ModelInput);
            

            foreach (var item in userInput)
            {
                PropertyInfo piInstance = diseaseType.GetProperty("Sym" + item);
                piInstance.SetValue(predictionData, (float)weights[item - 1]);


            }

            var result =MLModel1.PredictAllLabels(predictionData);

            foreach (var item in result)
            {
                if(Math.Round(item.Value * 100)>10)
                    finalResults.Add(new FinalResults { Id = Convert.ToInt32(item.Key), result = (int)Math.Round(item.Value * 100) });
            }

            return finalResults;


        }

        public class FinalResults
        {
            public int Id { get; set; }
            public int result { get; set; }

        }

    }

}
