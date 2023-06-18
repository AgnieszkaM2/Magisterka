using System;

namespace DiagnosticApp_API.System1
{
    public class Graph
    {
        private int completeSymptomsCount { get; set; }
        private int completeDiseasesCount { get; set; }
        private int[,] graphArray { get; set; }
        public Graph()
        {
            completeSymptomsCount = 226;
            completeDiseasesCount = 26;
            graphArray = new int[completeSymptomsCount, completeDiseasesCount];

        }
        public void AddEdge(int u, int v, int weight)
        {
            graphArray[u, v] = weight;
        }

        public List<FinalResults> Diagnose(List<DiseaseVertex> disease, int[] userInput, int accuracyLevel)
        {
            List<FoundDisease> foundDiseases = new List<FoundDisease>();
            List<Results> results = new List<Results>();
            List<FinalResults> finalResults = new List<FinalResults>();

            for (int l = 0; l < userInput.Length; l++)
            {
                int i = userInput[l] - 1;
                for (int j = 0; j < graphArray.GetLength(1); j++)
                {
                    if (graphArray[i, j] > 0)
                    {
                        if (foundDiseases.Exists(x => x.Id == j))
                        {
                            int index = foundDiseases.FindIndex(item => item.Id == j);
                            foundDiseases[index].Weight += graphArray[i, j];
                            foundDiseases[index].Count += 1;

                        }
                        else
                        {
                            foundDiseases.Add(new FoundDisease { Id = j, Weight = graphArray[i, j], Count = 1 });

                        }
                    }
                }

            }

            foreach (var item in disease)
            {
                int tempId = item.Id - 1;
                if (foundDiseases.Exists(x => x.Id == tempId))
                {
                    int index = foundDiseases.FindIndex(item => item.Id == tempId);
                    double tempCount = ((double)foundDiseases[index].Count / item.SumCount) * 100;
                    double tempWeight = ((double)foundDiseases[index].Weight / item.SumWeight) * 100;
                    var temp = (Math.Round(tempCount) + Math.Round(tempWeight)) / 2;
                    results.Add(new Results { Id = tempId + 1, Count = (int)Math.Round(tempCount), Weight = (int)Math.Round(tempWeight), Average = (int)temp });
                }
            }

            foreach (var item in results)
            {
                if (item.Average >= accuracyLevel)
                {
                    finalResults.Add(new FinalResults { Id = item.Id, result = item.Average });
                }
            }


            return finalResults;


        }



    }

    public class FoundDisease
    {
        public int Id { get; set; }
        public int Weight { get; set; }
        public int Count { get; set; }
    }

    public class Results
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int Weight { get; set; }
        public int Average { get; set; }
    }

    public class FinalResults
    {
        public int Id { get; set; }
        public int result { get; set; }

    }
    public class DiseaseVertex
    {
        public int Id { get; set; }
        public int SumWeight { get; set; }
        public int SumCount { get; set; }
    }

}
