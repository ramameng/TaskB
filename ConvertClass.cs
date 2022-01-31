using System;
using System.Numerics;

namespace TaskB
{
    public static class ConvertClass
    {
        public static string ProcessInput(this string input)
        {
            string _result = string.Empty;

            input = input.Trim();
            try
            {
                if (!input.Contains("."))
                {
                    if (input.Length > 21)
                        _result = new System.ArgumentOutOfRangeException(
                            input, "Number must be below quintillion level!").ToString();
                    else if (string.IsNullOrEmpty(input))
                        _result = new Exception("Input is not number!").ToString();
                    else if (input.Equals("0"))
                        _result = "ZERO";
                    else if (input.StartsWith('-'))
                    {
                        if (input.Substring(1).StartsWith("0"))
                            _result = new Exception("Input is not number!").ToString();
                        else if (BigInteger.Parse(input.Substring(1)) < 0)
                            _result = new Exception("Input is not number!").ToString();
                        else
                            _result = $"MINUS {ConvertWholeDigit(input.Substring(1))}";
                    }
                    else
                        _result = ConvertWholeDigit(input) + " DOLLARS";
                }
                else
                {
                    int splitIndex = input.IndexOf(".");
                    string number = input.Substring(0, splitIndex);
                    string decimals = input.Substring(splitIndex + 1);

                    if (number.Length > 21 && decimals.Length > 21)
                        _result = new System.ArgumentOutOfRangeException(input,
                            "Number must be below quintillion level!").ToString();
                    else
                    {
                        if (string.IsNullOrEmpty(number))
                            _result = new Exception("Input is not number!").ToString();
                        else if (number.Equals("0"))
                        {
                            if (decimals.Equals("0"))
                                _result = "ZERO DOLLAR AND ZERO CENTS";
                            else
                                _result = $"ZERO DOLLAR AND {ConvertWholeDigit(decimals)} CENTS";
                        }
                        else if (number.StartsWith('-'))
                        {
                            if (number.Substring(1).StartsWith("0"))
                            {
                                if (number.Substring(2).StartsWith("0"))
                                    _result = new Exception("Input is not number!").ToString();
                                else
                                    _result = $"MINUS ZERO DOLLAR AND {ConvertWholeDigit(decimals)} CENTS";
                            }
                            else if (BigInteger.Parse(number.Substring(1)) < 0)
                                _result = new Exception("Input is not number!").ToString();
                            else
                                _result = $"MINUS {ConvertWholeDigit(number.Substring(1))} DOLLARS AND {ConvertWholeDigit(decimals)} CENTS";
                        }
                        else
                            _result = $"{ConvertWholeDigit(number)} DOLLARS AND {ConvertWholeDigit(decimals)} CENTS";
                    }
                }
            }
            catch (Exception)
            {
                _result = new Exception("Input is not number!").ToString();
            }

            return _result;
        }

        private static string ConvertWholeDigit(string number)
        {
            string result = string.Empty;
            bool done = false;
            int length = number.Length;
            int store = 0;
            string word = string.Empty;

            switch (length)
            {
                case 1:
                    result = OneDigit(number);
                    done = true;
                    break;
                case 2:
                    result = TwoDigit(number);
                    done = true;
                    break;
                case 3:
                    store = (length % 3) + 1;
                    word = " HUNDRED " + ((BigInteger.Parse(number) % 100 > 0) ? "AND " : "");
                    break;
                case 4:
                case 5:
                case 6:
                    store = (length % 4) + 1;
                    if (number.Substring(0, store) != "000")
                        word = " THOUSAND " + (number.Substring(store, 1) == "0" && number.Substring(store, 3) != "000" ? "AND " : "");
                    break;
                case 7:
                case 8:
                case 9:
                    store = (length % 7) + 1;
                    if (number.Substring(0, store) != "000")
                        word = " MILLION ";
                    break;
                case 10:
                case 11:
                case 12:
                    store = (length % 10) + 1;
                    if (number.Substring(0, store) != "000")
                        word = " BILLION ";
                    break;
                case 13:
                case 14:
                case 15:
                    store = (length % 13) + 1;
                    if (number.Substring(0, store) != "000")
                        word = " TRILLION ";
                    break;
                case 16:
                case 17:
                case 18:
                    store = (length % 16) + 1;
                    if (number.Substring(0, store) != "000")
                        word = " QUADRILLION ";
                    break;
                case 19:
                case 20:
                case 21:
                    store = (length % 19) + 1;
                    if (number.Substring(0, store) != "000")
                        word = " QUINTILLION ";
                    break;
                default:
                    done = true;
                    break;
            }

            if (!done)
            {
                if (number.Substring(0, store) != "0" && number.Substring(store) != "0")
                {
                    result = $"{ConvertWholeDigit(number.Substring(0, store))}{word}{ConvertWholeDigit(number.Substring(store))}";
                }
                else
                    result = $"{ConvertWholeDigit(number.Substring(0, store))}{ConvertWholeDigit(number.Substring(store))}";
            }

            return result.Trim();
        }

        private static string OneDigit(string number)
        {
            int temp = int.Parse(number);
            string result = temp switch
            {
                1 => "ONE",
                2 => "TWO",
                3 => "THREE",
                4 => "FOUR",
                5 => "FIVE",
                6 => "SIX",
                7 => "SEVEN",
                8 => "EIGHT",
                9 => "NINE",
                _ => string.Empty
            };

            return result;
        }

        private static string TwoDigit(string number)
        {
            int temp = int.Parse(number);
            switch (temp)
            {
                case 10:
                    return "TEN";
                case 11:
                    return "ELEVEN";
                case 12:
                    return "TWELVE";
                case 13:
                    return "THIRTEEN";
                case 14:
                    return "FOURTEEN";
                case 15:
                    return "FIFTEEN";
                case 16:
                    return "SIXTEEN";
                case 17:
                    return "SEVENTEEN";
                case 18:
                    return "EIGHTEEN";
                case 19:
                    return "NINETEEN";
                case 20:
                    return "TWENTY";
                case 30:
                    return "THIRTY";
                case 40:
                    return "FOURTY";
                case 50:
                    return "FIFTY";
                case 60:
                    return "SIXTY";
                case 70:
                    return "SEVENTY";
                case 80:
                    return "EIGHTY";
                case 90:
                    return "NINETY";
                default:
                    if (temp > 0)
                    {
                        if (number.Substring(0, 1) != "0")
                            return $"{TwoDigit(number.Substring(0, 1) + "0")}-{OneDigit(number.Substring(1))}";
                        else
                            return OneDigit(number.Substring(1));
                    }
                    break;
            }

            return string.Empty;
        }
    }
}
