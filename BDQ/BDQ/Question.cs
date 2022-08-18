using System;



namespace BDqus
{
        internal class Question
        {
            public string? Ques { get; }
            public string[]? Unsers { get; }
            public int[]? RightUnsers { get; }

            public Question(string? ques, string[]? unsers, int[]? rightunsers)
            {
                Ques = ques;
                Unsers = unsers;
                RightUnsers = rightunsers;
            }


        }
}

