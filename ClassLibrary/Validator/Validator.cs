using ClassLibrary.Parser;

namespace ClassLibrary.Validator
{
    public class Validator : IValidator
    {
        private bool CheckBrackets(string example, char leftBracket, char rightBracket)
        {
            int length = example.Length;
            int check = 0;
            for (int i = 0; i < length; i++)
            {
                if (example[i] == leftBracket)
                {
                    check++;
                }
                if (example[i] == rightBracket)
                {
                    check--;
                }
            }
            return check == 0;
        }

        private bool CheckLength(string example)
        {
            return example.Length > 0;
        }

        private bool CheckBrackets(string example)
        {
            return CheckBrackets(example, '(', ')');
        }

        public bool Validate(string example)
        {
            return CheckLength(example) && CheckBrackets(example);
        }
    }
}