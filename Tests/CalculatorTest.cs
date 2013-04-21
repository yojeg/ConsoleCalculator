using ClassLibrary;
using ClassLibrary.Operations;
using ClassLibrary.Parser;
using ClassLibrary.Validator;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class CalculatorTest
    {
        private Calculator _calculator;
        private IValidator _validator;
        private IParser _parser;

        [SetUp]
        public void testsSetup()
        {
            _validator = new Validator();
            _parser = new PostfixNotationParser();
            _calculator = new Calculator(_validator, _parser);
            _calculator
                .AddOperation(new LeftBracket())
                .AddOperation(new RightBracket())
                .AddOperation(new PlusOperation())
                .AddOperation(new MinusOperation())
                .AddOperation(new MultiplyOperation());
            _parser.SetOperationSigns(_calculator.GetOperations());
        }

        [Test]
        public void testBaseMathOperations()
        {
            _calculator.SetExample("1+1-2");
            Assert.AreEqual(0, _calculator.Calculate());
        }

        [Test]
        public void ParserTest()
        {
            string example = "4+1";
            Assert.AreEqual(3, _parser.Parse(example).Count());
            Assert.AreEqual("+", _parser.Parse(example)[2]);
        }

        [Test]
        public void testCheckBrackets()
        {
            string str = "(1+1)*1";
            Assert.True(_validator.Validate(str));
            str = "(1+1)*(2+4";
            Assert.False(_validator.Validate(str));
        }

        [Test]
        public void testOperationRaring()
        {
            var example = "1+1*2";
            _calculator.SetExample(example);
            Assert.AreEqual(3, _calculator.Calculate());
        }
  }
}
