﻿namespace CSharpDiscovery
{
    using System.Collections.Generic;
    using System.Linq;
    using NFluent;
    using NUnit.Framework;

    [TestFixture]
    public class LinqTests
    {
        [Test]
        public void UseAForeachLoopToSelectItemsStartingWithPlCaseSentitive()
        {
            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
            var search = new[] { "plip", "plop", "plup" };
            var filteredItems = new List<string>();

            foreach (var item in items)
            {
                if (search.Contains(item))
                {
                    filteredItems.Add(item);
                }
            }

            Check.That(filteredItems).ContainsExactly("plip", "plop", "plup");
        }

        [Test]
        public void TransformPreviousForeachLoopInALinqExpression()
        {
            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
            var search = new[] { "plip", "plop", "plup" };
            var filteredItems = new List<string>();
            filteredItems = items.Where(item => search.Contains(item)).ToList();
            // use from in/where/select LINQ syntax to the same filter as with the foreach loop
            // var filteredItems = from ...
            Check.That(filteredItems).ContainsExactly("plip", "plop", "plup");
        }

        [Test]
        public void ReplacePreviousLinqExpressionWithLinqExtensionMethodsOfIEnumerable()
        {
            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
            var search = new[] { "plip", "plop", "plup" };
            var filteredItems = new List<string>();
            // use System.Linq.Enumerable extension methods
            filteredItems = items.Where(item => search.Contains(item)).ToList();

            Check.That(filteredItems).ContainsExactly("plip", "plop", "plup");
        }

        [Test]
        public void UseSelectExtensionMethodToTransformFilteredItemsToUpperCase()
        {
            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
            var search = new[] { "PLIP", "PLOP", "PLUP" };
            var filteredItems = new List<string>();
            // use System.Linq.Enumerable extension methods
            filteredItems = items.Where(item => search.Contains(item.ToUpper())).ToList();
            filteredItems = filteredItems.ConvertAll(d => d.ToUpper());

            Check.That(filteredItems).ContainsExactly("PLIP", "PLOP", "PLUP");
        }

//        [Test]
//        public void UseSkipAndTakeToKeepElementsAtAGivenRange()
//        {
//            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
//            // use System.Linq.Enumerable extension methods
//            Check.That(twoElementsStartingAtFourth).ContainsExactly("plop", "plup");
//        }

        [Test]
        public void UseFirstToSelectFirstElementMatchingACondition()
        {
            var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
            // use First to retrieve the first item having an 'o' at third position
            string firstItemHavingAnOAtThirdPosition = items.First(item => item.Substring(2,2) == "o");
        
            Check.That(firstItemHavingAnOAtThirdPosition).Equals("foo");
        }

        //[Test]
        //public void FirstThrowsAnExceptionWhenConditionMatchesNoElement()
        //{
        //    var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
        //    // Action firstWithAConditionMatchingNoElements = lambda using First filtering item == "plep"
        //    Check.That(firstWithAConditionMatchingNoElements).Throws<InvalidOperationException>();
        //}

        //[Test]
        //public void FirstOrDefaultReturnsNullWhenConditionMatchesNoElement()
        //{
        //    var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
        //    // use FirstOrDefault filtering item == "plep"
        //    Check.That(firstItemEqualsToPlep).IsNull();
        //}

        //[Test]
        //public void SingleThrowsAnExceptionIfSeveralItemMatches()
        //{
        //    var items = new[] { "plip", "foo", "bar", "plop", "plup", "Plap" };
        //    // Action singleItemHavingAnOAtThirdPosition = use Single with condition on third character being an 'o'
        //    Check.ThatCode(singleItemHavingAnOAtThirdPosition).Throws<InvalidOperationException>();
        //}

        //[Test]
        //public void UseAggregateToComputeASum()
        //{
        //    var valuesToSum = new[] {1.2, 1.5, 5.3};
        //    // use Aggregate giving a lambda expression that make the sum of two values => iteration is done by the Aggregate method, using this lambda expression at each iteration
        //    Check.That(sum).Equals(1.2 + 1.5 + 5.3);
        //}

        //[Test]
        //public void UseAggregateToConcatenateStringsFromArray()
        //{
        //    var strings = new[] {"plip", "plop", "plup"};
        //    // use Aggregate with a seed value t
        //    Check.That(concatenatedString).Equals("Values of array are : , plip, plop, plup");
        //}
    }
}
