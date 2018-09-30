using System.Collections.Generic;

namespace Lab2
{
    public class LearningNumberList : LearningList
    {

        public override List<LearningListItem> List { get; set; }
        public LearningNumberList()
        {
            List = new List<LearningListItem>()
            {
                new LearningListItem()
                {
                    Value = '0',
                    image = new double[] {1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1}
                },
            new LearningListItem()
            {
                Value = '1',
                image = new double[] {0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1}
            },
            new LearningListItem()
            {
                Value = '2',
                image = new double[] {1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1}
            },
            new LearningListItem()
            {
                Value = '3',
                image = new double[] {1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1}
            },
            new LearningListItem()
            {
                Value = '4',
                image = new double[] {1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1}
            },
            new LearningListItem()
            {
                Value = '5',
                image = new double[] {1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1}
            },
            new LearningListItem()
            {
                Value = '6',
                image = new double[] {1, 1, 1, 1, 0,0 , 1, 1, 1, 1, 0, 1, 1, 1, 1}
            },
            new LearningListItem()
            {
                Value = '7',
                image = new double[] {1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1}
            },
            new LearningListItem()
            {
                Value = '8',
                image = new double[] {1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1}
            },
            new LearningListItem()
            {
                Value = '9',
                image = new double[] {1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1}
            },


            };
        }
    }

    public class LearningWordAnswer:LearningList
    {
        public LearningWordAnswer()
        {
            List = new List<LearningListItem>()
            {
                new LearningListItem()
                {
                    Value = 'A',
                    image = new double[]
                    {
                        0,0,0,1,1,0,0,0,
                        0,0,1,1,1,1,0,0,
                        0,1,1,0,0,1,1,0,
                        0,1,1,0,0,1,1,0,
                        0,1,1,1,1,1,1,0,
                        0,1,1,0,0,1,1,0,
                        0,1,1,0,0,1,1,0,
                        0,1,1,0,0,1,1,0,
                    }
                },
                new LearningListItem()
                {
                    Value = 'B',
                    image = new double[]
                    {
                        0,1,1,1,1,1,0,0,
                        0,1,1,0,0,0,1,0,
                        0,1,1,0,0,0,1,0,
                        0,1,1,1,1,1,0,0,
                        0,1,1,1,1,1,0,0,
                        0,1,1,0,0,0,1,0,
                        0,1,1,0,0,0,1,0,
                        0,1,1,1,1,1,0,0,
                    }
                },
                new LearningListItem()
                {
                    Value = 'C',
                    image = new double[]
                    {
                        0,0,1,1,1,1,0,0,
                        0,1,1,1,1,1,1,0,
                        1,1,1,0,0,1,1,0,
                        1,1,1,0,0,0,0,0,
                        1,1,1,0,0,0,0,0,
                        1,1,1,0,0,1,1,0,
                        0,1,1,1,1,1,1,0,
                        0,0,1,1,1,1,0,0,
                    }
                },
                new LearningListItem()
                {
                    Value = 'D',
                    image = new double[]
                    {
                        0,1,1,1,1,1,0,0,
                        0,1,1,1,1,1,1,0,
                        0,1,1,0,0,1,1,1,
                        0,1,1,0,0,1,1,1,
                        0,1,1,0,0,1,1,1,
                        0,1,1,0,0,1,1,1,
                        0,1,1,0,0,1,1,0,
                        0,1,1,1,1,1,0,0,
                    }
                },
                new LearningListItem()
                {
                    Value = 'E',
                    image = new double[]
                    {
                        0,1,1,1,1,1,1,0,
                        0,1,1,1,1,1,1,0,
                        0,1,1,0,0,0,0,0,
                        0,1,1,1,1,1,0,0,
                        0,1,1,1,1,1,0,0,
                        0,1,1,0,0,0,0,0,
                        0,1,1,1,1,1,1,0,
                        0,1,1,1,1,1,1,0,
                    }
                },
                new LearningListItem()
                {
                    Value = 'F',
                    image = new double[]
                    {
                        0,1,1,1,1,1,1,0,
                        0,1,1,1,1,1,1,0,
                        0,1,1,0,0,0,0,0,
                        0,1,1,0,0,0,0,0,
                        0,1,1,1,1,0,0,0,
                        0,1,1,1,1,0,0,0,
                        0,1,1,0,0,0,0,0,
                        0,1,1,0,0,0,0,0,
                    }
                },
                new LearningListItem()
                {
                    Value = 'T',
                    image = new double[]
                    {
                        0,1,1,1,1,1,1,0,
                        0,1,1,1,1,1,1,0,
                        0,0,0,1,1,0,0,0,
                        0,0,0,1,1,0,0,0,
                        0,0,0,1,1,0,0,0,
                        0,0,0,1,1,0,0,0,
                        0,0,0,1,1,0,0,0,
                        0,0,0,1,1,0,0,0,
                    }
                },

            };
        }

        public override List<LearningListItem> List { get; set; }
    }
    public class LearningListItem
    {
        public double[] image;
        public char Value;
    }

    public abstract class LearningList
    {
        public abstract List<LearningListItem> List { get; set; }
    }
}