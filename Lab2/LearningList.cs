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
                    image = new int[] {1, 1, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1}
                },
            new LearningListItem()
            {
                Value = '1',
                image = new int[] {0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1}
            },
            new LearningListItem()
            {
                Value = '2',
                image = new int[] {1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 1}
            },
            new LearningListItem()
            {
                Value = '3',
                image = new int[] {1, 1, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1}
            },
            new LearningListItem()
            {
                Value = '4',
                image = new int[] {1, 0, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1}
            },
            new LearningListItem()
            {
                Value = '5',
                image = new int[] {1, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 1}
            },
            new LearningListItem()
            {
                Value = '6',
                image = new int[] {1, 1, 1, 1, 0,0 , 1, 1, 1, 1, 0, 1, 1, 1, 1}
            },
            new LearningListItem()
            {
                Value = '7',
                image = new int[] {1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 1}
            },
            new LearningListItem()
            {
                Value = '8',
                image = new int[] {1, 1, 1, 1, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1}
            },
            new LearningListItem()
            {
                Value = '9',
                image = new int[] {1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1}
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
                    image = new int[]
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
                    image = new int[]
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
                    image = new int[]
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
                    image = new int[]
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
                    image = new int[]
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
                    image = new int[]
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
                    image = new int[]
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
        public int[] image;
        public char Value;
    }

    public abstract class LearningList
    {
        public abstract List<LearningListItem> List { get; set; }
    }
}