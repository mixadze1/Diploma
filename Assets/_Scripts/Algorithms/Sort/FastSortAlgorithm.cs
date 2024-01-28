using System.Threading;
using System.Threading.Tasks;
using _Scripts.Entities;

namespace _Scripts.Algorithms.Sort
{
    public class FastSortAlgorithm : AlgorithmBase
    {
        public override void Sort(AlgorithmEntity[] entities)
        {
            Task task = SortArray(entities, 0, entities.Length - 1);
            Helpers.ExceptionTaskHandler(task);
        }

        private async Task<AlgorithmEntity[]> SortArray(AlgorithmEntity[] array, int leftIndex, int rightIndex)
        {
            CancellationTokenSource = new CancellationTokenSource();
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex].Value;
            while (i <= j)
            {
                while (array[i].Value < pivot)
                {
                    i++;
                }
        
                while (array[j].Value > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i].Value;
                    array[i].SetValue(array[j].Value);
                    array[j].SetValue(temp);
                    i++;
                    j--;
                }
                await Task.Delay(DurationInMs);
            }

            if (leftIndex < j)
                SortArray(array, leftIndex, j);
            if (i < rightIndex)
                SortArray(array, i, rightIndex);
            return array;
        }

        public override string GetNameAlgorithm() => 
            "Fast sorting";
    }
}