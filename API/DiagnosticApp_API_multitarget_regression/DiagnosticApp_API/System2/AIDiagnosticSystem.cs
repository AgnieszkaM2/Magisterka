using Microsoft.ML;
using System.Reflection;

namespace DiagnosticApp_API.System2
{
    public class AIDiagnosticSystem
    {
        public static List<FinalResults> Diagnose(int[] userInput, int accuracyLevel)
        {
            List<FinalResults> finalResults = new List<FinalResults>();
            int[] weights = new int[] { 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 3, 1, 1, 2, 5, 1, 1, 3, 3, 5, 5, 3, 1, 3, 3, 3, 5, 5, 1, 5, 3, 3, 5, 2, 1, 3, 2, 1, 5, 5, 3, 1, 3, 3, 5, 3, 2, 3, 5, 5, 3, 3, 3, 1, 1, 1, 1, 5, 1, 1, 3, 3, 1, 1, 2, 2, 5, 2, 2, 3, 3, 2, 5, 3, 5, 5, 1, 2, 1, 5, 3, 3, 3, 5, 5, 2, 3, 3, 3, 3, 3, 3, 5, 3, 5, 3, 5, 3, 3, 3, 3, 3, 3, 2, 2, 5, 3, 3, 3, 3, 3, 1, 3, 3, 3, 5, 1, 2, 1, 5, 3, 3, 5, 3, 3, 3, 3, 3, 3, 3, 5, 5, 5, 3, 5, 3, 3, 2, 5, 5, 3, 3, 3, 3, 5, 5, 3, 3, 5, 3, 2, 3, 3, 3, 5, 3, 5, 3, 3, 3, 3, 3, 5, 1, 3, 3, 2, 3, 3, 3, 5, 3, 3, 3, 5, 3, 5, 2, 3, 3, 3, 3, 3, 5, 5, 3, 5, 5, 5, 3, 5, 2, 2, 3, 5, 5, 3, 5, 5, 5, 3, 5, 3, 5, 3, 3, 3, 3, 5, 3, 3, 3, 3, 5, 3, 5, 3, 5, 5, 3, 3, 3, 3, 3, 5, 5 };
            var predictionData1 = new ML_Disease1.ModelInput();
            Type disease1Type = typeof(ML_Disease1.ModelInput);
            var predictionData2 = new ML_Disease2.ModelInput();
            Type disease2Type = typeof(ML_Disease2.ModelInput);
            var predictionData3 = new ML_Disease3.ModelInput();
            Type disease3Type = typeof(ML_Disease3.ModelInput);
            var predictionData4 = new ML_Disease4.ModelInput();
            Type disease4Type = typeof(ML_Disease4.ModelInput);
            var predictionData5 = new ML_Disease5.ModelInput();
            Type disease5Type = typeof(ML_Disease5.ModelInput);
            var predictionData6 = new ML_Disease6.ModelInput();
            Type disease6Type = typeof(ML_Disease6.ModelInput);
            var predictionData7 = new ML_Disease7.ModelInput();
            Type disease7Type = typeof(ML_Disease7.ModelInput);
            var predictionData8 = new ML_Disease8.ModelInput();
            Type disease8Type = typeof(ML_Disease8.ModelInput);
            var predictionData9 = new ML_Disease9.ModelInput();
            Type disease9Type = typeof(ML_Disease9.ModelInput);
            var predictionData10 = new ML_Disease10.ModelInput();
            Type disease10Type = typeof(ML_Disease10.ModelInput);
            var predictionData11 = new ML_Disease11.ModelInput();
            Type disease11Type = typeof(ML_Disease11.ModelInput);
            var predictionData12 = new ML_Disease12.ModelInput();
            Type disease12Type = typeof(ML_Disease12.ModelInput);
            var predictionData13 = new ML_Disease13.ModelInput();
            Type disease13Type = typeof(ML_Disease13.ModelInput);
            var predictionData14 = new ML_Disease14.ModelInput();
            Type disease14Type = typeof(ML_Disease14.ModelInput);
            var predictionData15 = new ML_Disease15.ModelInput();
            Type disease15Type = typeof(ML_Disease15.ModelInput);
            var predictionData16 = new ML_Disease16.ModelInput();
            Type disease16Type = typeof(ML_Disease16.ModelInput);
            var predictionData17 = new ML_Disease17.ModelInput();
            Type disease17Type = typeof(ML_Disease17.ModelInput);
            var predictionData18 = new ML_Disease18.ModelInput();
            Type disease18Type = typeof(ML_Disease18.ModelInput);
            var predictionData19 = new ML_Disease19.ModelInput();
            Type disease19Type = typeof(ML_Disease19.ModelInput);
            var predictionData20 = new ML_Disease20.ModelInput();
            Type disease20Type = typeof(ML_Disease20.ModelInput);
            var predictionData21 = new ML_Disease21.ModelInput();
            Type disease21Type = typeof(ML_Disease21.ModelInput);
            var predictionData22 = new ML_Disease22.ModelInput();
            Type disease22Type = typeof(ML_Disease22.ModelInput);
            var predictionData23 = new ML_Disease23.ModelInput();
            Type disease23Type = typeof(ML_Disease23.ModelInput);
            var predictionData24 = new ML_Disease24.ModelInput();
            Type disease24Type = typeof(ML_Disease24.ModelInput);
            var predictionData25 = new ML_Disease25.ModelInput();
            Type disease25Type = typeof(ML_Disease25.ModelInput);
            var predictionData26 = new ML_Disease26.ModelInput();
            Type disease26Type = typeof(ML_Disease26.ModelInput);

            foreach (var item in userInput)
            {
                PropertyInfo piInstance1 = disease1Type.GetProperty("Sym" + item);
                piInstance1.SetValue(predictionData1, (float)weights[item - 1]);
                PropertyInfo piInstance2 = disease2Type.GetProperty("Sym" + item);
                piInstance2.SetValue(predictionData2, (float)weights[item - 1]);
                PropertyInfo piInstance3 = disease3Type.GetProperty("Sym" + item);
                piInstance3.SetValue(predictionData3, (float)weights[item - 1]);
                PropertyInfo piInstance4 = disease4Type.GetProperty("Sym" + item);
                piInstance4.SetValue(predictionData4, (float)weights[item - 1]);
                PropertyInfo piInstance5 = disease5Type.GetProperty("Sym" + item);
                piInstance5.SetValue(predictionData5, (float)weights[item - 1]);
                PropertyInfo piInstance6 = disease6Type.GetProperty("Sym" + item);
                piInstance6.SetValue(predictionData6, (float)weights[item - 1]);
                PropertyInfo piInstance7 = disease7Type.GetProperty("Sym" + item);
                piInstance7.SetValue(predictionData7, (float)weights[item - 1]);
                PropertyInfo piInstance8 = disease8Type.GetProperty("Sym" + item);
                piInstance8.SetValue(predictionData8, (float)weights[item - 1]);
                PropertyInfo piInstance9 = disease9Type.GetProperty("Sym" + item);
                piInstance9.SetValue(predictionData9, (float)weights[item - 1]);
                PropertyInfo piInstance10 = disease10Type.GetProperty("Sym" + item);
                piInstance10.SetValue(predictionData10, (float)weights[item - 1]);
                PropertyInfo piInstance11 = disease11Type.GetProperty("Sym" + item);
                piInstance11.SetValue(predictionData11, (float)weights[item - 1]);
                PropertyInfo piInstance12 = disease12Type.GetProperty("Sym" + item);
                piInstance12.SetValue(predictionData12, (float)weights[item - 1]);
                PropertyInfo piInstance13 = disease13Type.GetProperty("Sym" + item);
                piInstance13.SetValue(predictionData13, (float)weights[item - 1]);
                PropertyInfo piInstance14 = disease14Type.GetProperty("Sym" + item);
                piInstance14.SetValue(predictionData14, (float)weights[item - 1]);
                PropertyInfo piInstance15 = disease15Type.GetProperty("Sym" + item);
                piInstance15.SetValue(predictionData15, (float)weights[item - 1]);
                PropertyInfo piInstance16 = disease16Type.GetProperty("Sym" + item);
                piInstance16.SetValue(predictionData16, (float)weights[item - 1]);
                PropertyInfo piInstance17 = disease17Type.GetProperty("Sym" + item);
                piInstance17.SetValue(predictionData17, (float)weights[item - 1]);
                PropertyInfo piInstance18 = disease18Type.GetProperty("Sym" + item);
                piInstance18.SetValue(predictionData18, (float)weights[item - 1]);
                PropertyInfo piInstance19 = disease19Type.GetProperty("Sym" + item);
                piInstance19.SetValue(predictionData19, (float)weights[item - 1]);
                PropertyInfo piInstance20 = disease20Type.GetProperty("Sym" + item);
                piInstance20.SetValue(predictionData20, (float)weights[item - 1]);
                PropertyInfo piInstance21 = disease21Type.GetProperty("Sym" + item);
                piInstance21.SetValue(predictionData21, (float)weights[item - 1]);
                PropertyInfo piInstance22 = disease22Type.GetProperty("Sym" + item);
                piInstance22.SetValue(predictionData22, (float)weights[item - 1]);
                PropertyInfo piInstance23 = disease23Type.GetProperty("Sym" + item);
                piInstance23.SetValue(predictionData23, (float)weights[item - 1]);
                PropertyInfo piInstance24 = disease24Type.GetProperty("Sym" + item);
                piInstance24.SetValue(predictionData24, (float)weights[item - 1]);
                PropertyInfo piInstance25 = disease25Type.GetProperty("Sym" + item);
                piInstance25.SetValue(predictionData25, (float)weights[item - 1]);
                PropertyInfo piInstance26 = disease26Type.GetProperty("Sym" + item);
                piInstance26.SetValue(predictionData26, (float)weights[item - 1]);


            }
            var result1 = ML_Disease1.Predict(predictionData1).Score;
            var result2 = ML_Disease2.Predict(predictionData2).Score;
            var result3 = ML_Disease3.Predict(predictionData3).Score;
            var result4 = ML_Disease4.Predict(predictionData4).Score;
            var result5 = ML_Disease5.Predict(predictionData5).Score;
            var result6 = ML_Disease6.Predict(predictionData6).Score;
            var result7 = ML_Disease7.Predict(predictionData7).Score;
            var result8 = ML_Disease8.Predict(predictionData8).Score;
            var result9 = ML_Disease9.Predict(predictionData9).Score;
            var result10 = ML_Disease10.Predict(predictionData10).Score;
            var result11 = ML_Disease11.Predict(predictionData11).Score;
            var result12 = ML_Disease12.Predict(predictionData12).Score;
            var result13 = ML_Disease13.Predict(predictionData13).Score;
            var result14 = ML_Disease14.Predict(predictionData14).Score;
            var result15 = ML_Disease15.Predict(predictionData15).Score;
            var result16 = ML_Disease16.Predict(predictionData16).Score;
            var result17 = ML_Disease17.Predict(predictionData17).Score;
            var result18 = ML_Disease18.Predict(predictionData18).Score;
            var result19 = ML_Disease19.Predict(predictionData19).Score;
            var result20 = ML_Disease20.Predict(predictionData20).Score;
            var result21 = ML_Disease21.Predict(predictionData21).Score;
            var result22 = ML_Disease22.Predict(predictionData22).Score;
            var result23 = ML_Disease23.Predict(predictionData23).Score;
            var result24 = ML_Disease24.Predict(predictionData24).Score;
            var result25 = ML_Disease25.Predict(predictionData25).Score;
            var result26 = ML_Disease26.Predict(predictionData26).Score;

            int[] results = { (int)Math.Round(Math.Abs(result1)), (int)Math.Round(Math.Abs(result2)), (int)Math.Round(Math.Abs(result3)), (int)Math.Round(Math.Abs(result4)), (int)Math.Round(Math.Abs(result5)), (int)Math.Round(Math.Abs(result6)), (int)Math.Round(Math.Abs(result7)), (int)Math.Round(Math.Abs(result8)), (int)Math.Round(Math.Abs(result9)), (int)Math.Round(Math.Abs(result10)), (int)Math.Round(Math.Abs(result11)), (int)Math.Round(Math.Abs(result12)), (int)Math.Round(Math.Abs(result13)), (int)Math.Round(Math.Abs(result14)), (int)Math.Round(Math.Abs(result15)), (int)Math.Round(Math.Abs(result16)), (int)Math.Round(Math.Abs(result17)), (int)Math.Round(Math.Abs(result18)), (int)Math.Round(Math.Abs(result19)), (int)Math.Round(Math.Abs(result20)), (int)Math.Round(Math.Abs(result21)), (int)Math.Round(Math.Abs(result22)), (int)Math.Round(Math.Abs(result23)), (int)Math.Round(Math.Abs(result24)), (int)Math.Round(Math.Abs(result25)), (int)Math.Round(Math.Abs(result26)) };
            int index = 1;
            foreach (var item in results)
            {
                if (item >=accuracyLevel)
                    finalResults.Add(new FinalResults { Id = index, result = item });


                index++;
            }

            return finalResults;




        }
    }

    public class FinalResults
    {
        public int Id { get; set; }
        public int result { get; set; }

    }


}
