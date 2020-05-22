using System;
using FluentAssertions;
using Machine.Specifications;

namespace Kata.Spec
{
    public class when_feeding_the_monkey
    {
        static Monkey _systemUnderTest;
        
        Establish context = () => 
            _systemUnderTest = new Monkey();

        Because of = () => 
            _systemUnderTest.Eat("banana");

        It should_have_the_food_in_its_belly = () =>
            _systemUnderTest.Belly.Should().Contain("banana");
    }

    public class when_input_is_empty
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };
        Because of = () => { _result = _systemUnderTest.Sum(); };
        It should_return_zero = () => { _result.Should().Be(0); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_onenumber

    {

        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Sum("3"); };

        It should_return_same_number = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_are_two_numbers
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };
        Because of = () => { _result = _systemUnderTest.Sum("2,2"); };
        It should_return_sum_of_numbers = () => { _result.Should().Be(4); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_unknown_amount_of_number

    {
        private Establish _context = () => { _systemUnderTest = new Calculator();
        };

        Because of = () => { _result = _systemUnderTest.Sum("1,2,3"); };

        It should_return_sum_all_number = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_input_is_multiple_with_new_line
    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };
        Because of = () => { _result = _systemUnderTest.Sum("1\n2,3"); };
        It should_return_sum = () => { _result.Should().Be(6); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }

    public class when_multiple_number_custom_single_character    

    {

        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => { _result = _systemUnderTest.Sum("//;\n1;2"); };

        It should_do_something = () => { _result.Should().Be(3); };
        private static Calculator _systemUnderTest;
        private static int _result;
    }


    public class when_negative_number

    {
        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => _result = Catch.Exception(() => { _systemUnderTest.Sum("-1"); });

        private It should_throw_exception = () => { _result.Message.Should().Contain("negatives not allowed: -1"); };
        private static Calculator _systemUnderTest;
        private static Exception _result;
    }

    public class when_multiple_negative_number

    {

        Establish _context = () => { _systemUnderTest = new Calculator(); };

        Because of = () => _result = Catch.Exception(() => { _systemUnderTest.Sum("-1,-2,3,-4,0"); });

        private It should_throw_exception = () => { _result.Message.Should().Contain("negatives not allowed: -1,-2,-4"); };
        private static Calculator _systemUnderTest;
        private static Exception _result;

    }
    
   
    // Given the user input contains numbers larger than 1000 when calculating the sum it should only sum the numbers less than 1001. (example 2 + 1001 = 2)
    // Given the user input is multiple numbers with a custom multi-character delimiter when calculating the sum then it should return the sum of all the numbers. (example: “//[]\n12***3” should return 6)
    // Given the user input is multiple numbers with multiple custom delimiters when calculating the sum then it should return the sum of all the numbers. (example “//[][%]\n12%3” should return 6)
}