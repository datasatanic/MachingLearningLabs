using System.Collections.Generic;

namespace Lab2
{
    public class NeuralNetwork
    {
        private char Target { get; set; }
        private LearningList L;
        private List<Neiron> Neirons = new List<Neiron>();

        public NeuralNetwork(int inputCount, LearningList l)
        {
            L = l;
            Neirons.Add(new Neiron(inputCount));
            Learning();
        }

        public void ChangeTarget(char t)
        {
            Target = t;
            Learning();
        }

        private void Learning()
        {
            bool f = false;
            while (!f)
            {
                f = true;
                foreach (var item in L.List)
                {
                    Neirons[0].Learn(item.image, (item.Value == Target) ? 1 : -1);
                }

                for (int i = 0; i < L.List.Count; i++)
                {
                    if (Neirons[0].Schet(L.List[i].image) != ((L.List[i].Value == Target) ? 1 : -1))
                        f = false;
                }
            }
        }

        public string Check(double[] check)
        {
            return (Neirons[0].Schet(check) == 1) ? "Да" : "Нет";
        }
    }
}