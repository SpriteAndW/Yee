#region 作者

//===================================================||
//作者：溫柔可愛柠檬草  (b站)
//===================================================||

#endregion

#region Library

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Numerics;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OfficeOpenXml;
using static System.String;
using static RootLibrary.QueryBuilder;

#endregion

#region Document

//Ctrl + M + O 快速折叠所有函数
//Ctrl + M + M 折叠或者展开当前方法
//===================================================||
//收录并改写了
//大部分unity的Mathf函数
//Java转C#的部分方法
//部分系统
//部分Crystal_AI内容
//禁止使用UnityEngine
//不继承Unity的任何脚本
//禁止依赖其它任何脚本
//禁止关联其它任何脚本

#endregion

// ReSharper disable once CheckNamespace
namespace RootLibrary
{
    #region Struct

    #region Math

    /// <summary>
    ///     数学函数库V
    /// </summary>
    public readonly struct MathV
    {
        #region Variable

        #region EnglishWords

        /// <summary>
        ///     个位
        /// </summary>
        public static readonly string[] Singles =
            { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

        /// <summary>
        ///     十位
        /// </summary>
        public static readonly string[] Teens =
        {
            "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
        };

        /// <summary>
        ///     数十位
        /// </summary>
        public static readonly string[] Tens =
            { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

        /// <summary>
        ///     数千位
        /// </summary>
        public static readonly string[] Thousands = { "", "Thousand", "Million", "Billion" };

        /// <summary>
        ///     英语日期
        /// </summary>
        public static readonly Dictionary<string, string> Date = new()
        {
            { "Jan", "01" },
            { "Feb", "02" },
            { "Mar", "03" },
            { "Apr", "04" },
            { "May", "05" },
            { "Jun", "06" },
            { "Jul", "07" },
            { "Aug", "08" },
            { "Sep", "09" },
            { "Oct", "10" },
            { "Nov", "11" },
            { "Dec", "12" }
        };

        #endregion

        /// <summary>
        ///     罗马数字符号
        /// </summary>
        public static readonly Tuple<int, string>[] RomeNumeralSymbols =
        {
            new(1000, "M"),
            new(900, "CM"),
            new(500, "D"),
            new(400, "CD"),
            new(100, "C"),
            new(90, "XC"),
            new(50, "L"),
            new(40, "XL"),
            new(10, "X"),
            new(9, "IX"),
            new(5, "V"),
            new(4, "IV"),
            new(1, "I")
        };

        /// <summary>
        ///     罗马数字符号值
        /// </summary>
        public static int GetRomeValue(char value)
        {
            return value switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => 0
            };
        }

        /// <summary>
        ///     光速
        /// </summary>
        public const long CLight = 299792458;

        /// <summary>
        ///     圆周率Π
        /// </summary>
        public const float Pi = 3.14159274f;

        /// <summary>
        ///     随机
        /// </summary>
        public static readonly Random RandomV = new();

        /// <summary>
        ///     UTF-8_1
        /// </summary>
        public const int Mask1 = 1 << 7;

        /// <summary>
        ///     UTF-8_2
        /// </summary>
        public const int Mask2 = (1 << 7) + (1 << 6);

        #endregion

        #region Core

        #region Base

        public static float Pow(float f, float p)
        {
            return (float)Math.Pow(f, p);
        }

        public static float Exp(float power)
        {
            return (float)Math.Exp(power);
        }

        public static float Log(float f, float p)
        {
            return (float)Math.Log(f, p);
        }

        public static float Log(float f)
        {
            return (float)Math.Log(f);
        }

        public static float Log10(float f)
        {
            return (float)Math.Log10(f);
        }

        public static float Ceil(float f)
        {
            return (float)Math.Ceiling(f);
        }

        public static float Floor(float f)
        {
            return (float)Math.Floor(f);
        }

        public static float Round(float f)
        {
            return (float)Math.Round(f);
        }

        public static int CeilToInt(float f)
        {
            return (int)Math.Ceiling(f);
        }

        public static int FloorToInt(float f)
        {
            return (int)Math.Floor(f);
        }

        public static int RoundToInt(float f)
        {
            return (int)Math.Round(f);
        }

        public static float Sign(float f)
        {
            return f >= 0.0 ? 1f : -1f;
        }

        public static float Sin(float f)
        {
            return (float)Math.Sin(f);
        }

        public static float Cos(float f)
        {
            return (float)Math.Cos(f);
        }

        public static float Tan(float f)
        {
            return (float)Math.Tan(f);
        }

        public static float Asin(float f)
        {
            return (float)Math.Asin(f);
        }

        public static float Acos(float f)
        {
            return (float)Math.Acos(f);
        }

        public static float Atan(float f)
        {
            return (float)Math.Atan(f);
        }

        public static float Atan2(float y, float x)
        {
            return (float)Math.Atan2(y, x);
        }

        public static float Sqrt(float f)
        {
            return (float)Math.Sqrt(f);
        }

        public static short Abs(short value)
        {
            return Math.Abs(value);
        }

        public static int Abs(int value)
        {
            return Math.Abs(value);
        }

        public static int Abs(int a, int b)
        {
            var value = a - b;
            return value > 0 ? value : -value;
        }

        public static long Abs(long value)
        {
            return Math.Abs(value);
        }

        public static long Abs(long a, long b)
        {
            var value = a - b;
            return value > 0 ? value : -value;
        }

        public static float Abs(float value)
        {
            return Math.Abs(value);
        }

        public static float Abs(float a, float b)
        {
            var value = a - b;
            return value > 0 ? value : -value;
        }

        public static decimal Abs(decimal value)
        {
            return Math.Abs(value);
        }

        public static decimal Abs(decimal a, decimal b)
        {
            var value = a - b;
            return value > 0 ? value : -value;
        }

        public static double Abs(double value)
        {
            return Math.Abs(value);
        }

        public static double Abs(double a, double b)
        {
            var value = a - b;
            return value > 0 ? value : -value;
        }

        #endregion

        #region Extend

        public static float Repeat(float t, float length)
        {
            return Clamp(t - Floor(t / length) * length, 0.0f, length);
        }

        public static float MoveTowards(float current, float target, float maxDelta)
        {
            return Abs(target - current) <= (double)maxDelta ? target : current + Sign(target - current) * maxDelta;
        }

        public static float MoveTowardsAngle(float current, float target, float maxDelta)
        {
            var num = DeltaAngle(current, target);
            if (-(double)maxDelta < num && num < (double)maxDelta)
                return target;
            return MoveTowards(current, current + num, maxDelta);
        }

        public static float PingPong(float t, float length)
        {
            return length - Abs(Repeat(t, length * 2f) - length);
        }

        public static float SmoothStep(float from, float to, float t)
        {
            t = Clamp01(t);
            t = (float)(-2.0 * t * t * t + 3.0 * t * t);
            return (float)(to * (double)t + from * (1.0 - t));
        }

        public static float Gamma(float value, float absMax, float gamma)
        {
            var flag = value < 0.0;
            var num1 = Abs(value);
            if (num1 > (double)absMax)
                return flag ? -num1 : num1;
            return flag ? -Pow(num1 / absMax, gamma) * absMax : Pow(num1 / absMax, gamma) * absMax;
        }

        public static float InverseLerp(float a, float b, float value)
        {
            return a.CompareTo((double)b) != 0 ? Clamp01((float)((value - (double)a) / (b - (double)a))) : 0.0f;
        }

        public static float DeltaAngle(float current, float target)
        {
            var num = Repeat(target - current, 360f);
            if (num > 180.0)
                num -= 360f;
            return num;
        }

        #endregion

        #region Physics

        /// <summary>
        ///     位移
        /// </summary>
        public static float Distance(float x, float y)
        {
            return Sqrt(Pow(x, 2) + Pow(y, 2));
        }

        /// <summary>
        ///     匀速圆周运动
        /// </summary>
        public static float UniformCircularMove(float r, float x)
        {
            return Sqrt(Pow(r, 2) - Pow(x, 2));
        }

        /// <summary>
        ///     抛物线a*x^2+bx+c
        /// </summary>
        public static float Parabola(float x, float a, float b, float c)
        {
            return a * Pow(x, 2) + b * x + c;
        }

        /// <summary>
        ///     自由落体运动0.5f*g*t^2
        /// </summary>
        public static float FreeFall(float g, float t)
        {
            return 0.5f * g * Pow(t, 2);
        }

        /// <summary>
        ///     平抛运动(g*x^2)/(2*v^2)
        /// </summary>
        public static float HorizontalCastMove(float g, float v, float x)
        {
            return g * Pow(x, 2) / (2 * Pow(v, 2));
        }

        /// <summary>
        ///     动能0.5f*m*v^2
        /// </summary>
        public static float KineticEnergy(float m, float v)
        {
            return 0.5f * m * Pow(v, 2);
        }

        /// <summary>
        ///     单摆周期
        /// </summary>
        public static float PendulumPeriod(float l, float g)
        {
            return 2 * Pi * Sqrt(l / g);
        }

        /// <summary>
        ///     弹簧振子周期
        /// </summary>
        public static float SpringOscillatorPeriod(float m, float k)
        {
            return 2 * Pi * Sqrt(m / k);
        }

        /// <summary>
        ///     安培力
        /// </summary>
        public static float AmpereForce(float b, float i, float l)
        {
            return b * i * l;
        }

        /// <summary>
        ///     时间相对性
        /// </summary>
        public static float TimeScale(float t, float v)
        {
            return t / Sqrt(1 - Pow(v / CLight, 2));
        }

        /// <summary>
        ///     长度相对性
        /// </summary>
        public static float LengthScale(float l, float v)
        {
            return l * Sqrt(1 - Pow(v / CLight, 2));
        }

        /// <summary>
        ///     质量相对性
        /// </summary>
        public static float QualityScale(float m, float v)
        {
            return m / Sqrt(1 - Pow(v / CLight, 2));
        }

        /// <summary>
        ///     速度叠加
        /// </summary>
        public static float VelocityStack(float u, float v)
        {
            return (u + v) / (1 + u * v / Pow(CLight, 2));
        }

        #endregion

        #region Lerp

        /// <summary>
        ///     插值（输入，输出，0-1百分比）
        /// </summary>
        public static float Lerp(float input, float output, float delta)
        {
            delta = Clamp01(delta);
            return Abs(output - input) <= Abs(delta) ? output : input + (output - input) * delta;
        }

        public static float LerpUnClamped(float input, float output, float delta)
        {
            return Abs(output - input) <= Abs(delta) ? output : input + (output - input) * delta;
        }

        #endregion

        #region Min & Max

        public static int Min(int a, int b)
        {
            return a > b ? b : a;
        }

        public static long Min(long a, long b)
        {
            return a > b ? b : a;
        }

        public static float Min(float a, float b)
        {
            return a > b ? b : a;
        }

        public static double Min(double a, double b)
        {
            return a > b ? b : a;
        }

        public static int Max(int a, int b)
        {
            return a > b ? a : b;
        }

        public static long Max(long a, long b)
        {
            return a > b ? a : b;
        }

        public static float Max(float a, float b)
        {
            return a > b ? a : b;
        }

        public static double Max(double a, double b)
        {
            return a > b ? a : b;
        }

        public static int Min(int[] tempArray)
        {
            var length = tempArray.Length;
            if (length == 0)
                return 0;
            var num = tempArray[0];
            for (var index = 1; index < length; ++index)
                if (tempArray[index] < num)
                    num = tempArray[index];
            return num;
        }

        public static int Min(List<int> tempList)
        {
            return Min(tempList.ToArray());
        }

        public static long Min(long[] tempArray)
        {
            var length = tempArray.Length;
            if (length == 0)
                return 0;
            var num = tempArray[0];
            for (var index = 1; index < length; ++index)
                if (tempArray[index] < num)
                    num = tempArray[index];
            return num;
        }

        public static long Min(List<long> tempList)
        {
            return Min(tempList.ToArray());
        }

        public static float Min(float[] tempArray)
        {
            var length = tempArray.Length;
            if (length == 0)
                return 0;
            var num = tempArray[0];
            for (var index = 1; index < length; ++index)
                if (tempArray[index] < num)
                    num = tempArray[index];
            return num;
        }

        public static float Min(List<float> tempList)
        {
            return Min(tempList.ToArray());
        }

        public static double Min(double[] tempArray)
        {
            var length = tempArray.Length;
            if (length == 0)
                return 0;
            var num = tempArray[0];
            for (var index = 1; index < length; ++index)
                if (tempArray[index] < num)
                    num = tempArray[index];
            return num;
        }

        public static double Min(List<double> tempList)
        {
            return Min(tempList.ToArray());
        }

        public static int Max(int[] tempArray)
        {
            var length = tempArray.Length;
            if (length == 0)
                return 0;
            var num = tempArray[0];
            for (var index = 1; index < length; ++index)
                if (tempArray[index] > num)
                    num = tempArray[index];
            return num;
        }

        public static int Max(List<int> tempList)
        {
            return Max(tempList.ToArray());
        }

        public static long Max(long[] tempArray)
        {
            var length = tempArray.Length;
            if (length == 0)
                return 0;
            var num = tempArray[0];
            for (var index = 1; index < length; ++index)
                if (tempArray[index] > num)
                    num = tempArray[index];
            return num;
        }

        public static long Max(List<long> tempList)
        {
            return Max(tempList.ToArray());
        }

        public static float Max(float[] tempArray)
        {
            var length = tempArray.Length;
            if (length == 0)
                return 0;
            var num = tempArray[0];
            for (var index = 1; index < length; ++index)
                if (tempArray[index] > num)
                    num = tempArray[index];
            return num;
        }

        public static float Max(List<float> tempList)
        {
            return Max(tempList.ToArray());
        }

        public static double Max(double[] tempArray)
        {
            var length = tempArray.Length;
            if (length == 0)
                return 0;
            var num = tempArray[0];
            for (var index = 1; index < length; ++index)
                if (tempArray[index] > num)
                    num = tempArray[index];
            return num;
        }

        public static double Max(List<double> tempList)
        {
            return Max(tempList.ToArray());
        }

        #endregion

        #region Clamp

        public static T Clamp<T>(T value, T min, T max) where T : IComparable<T>
        {
            if (min.CompareTo(max) > 0)
                return default;
            if (value.CompareTo(min) < 0)
                return min;
            return value.CompareTo(max) > 0 ? max : value;
        }

        public static float Clamp01(float value)
        {
            if (value < (double)0.0f)
                return 0.0f;
            return value > (double)1.0f ? 1.0f : value;
        }

        public static int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            return value > max ? max : value;
        }

        public static int ClampMin(int value, int min)
        {
            return value < min ? min : value;
        }

        public static int ClampMax(int value, int max)
        {
            return value > max ? max : value;
        }

        public static long Clamp(long value, long min, long max)
        {
            if (value < min)
                return min;
            return value > max ? max : value;
        }

        public static long ClampMin(long value, long min)
        {
            return value < min ? min : value;
        }

        public static long ClampMax(long value, long max)
        {
            return value > max ? max : value;
        }

        /// <summary>
        ///     钳制（输入，最小值，最大值）
        /// </summary>
        public static float Clamp(float value, float min, float max)
        {
            if (value < (double)min)
                return min;
            return value > (double)max ? max : value;
        }

        public static float ClampMin(float value, float min)
        {
            return value < (double)min ? min : value;
        }

        public static float ClampMax(float value, float max)
        {
            return value > (double)max ? max : value;
        }

        public static double Clamp(double value, double min, double max)
        {
            if (value < min)
                return min;
            return value > max ? max : value;
        }

        public static double ClampMin(double value, double min)
        {
            return value < min ? min : value;
        }

        public static double ClampMax(double value, double max)
        {
            return value > max ? max : value;
        }

        #endregion

        #region Random & Next

        public static bool NextBool()
        {
            return RandomV.NextDouble() > 0.5;
        }

        public static byte[] NextBytes(int length)
        {
            var data = new byte[length];
            RandomV.NextBytes(data);
            return data;
        }

        public static ushort NextUInt16()
        {
            return BitConverter.ToUInt16(NextBytes(2), 0);
        }

        public static short NextInt16()
        {
            return BitConverter.ToInt16(NextBytes(2), 0);
        }

        public static float NextFloat()
        {
            return BitConverter.ToSingle(NextBytes(4), 0);
        }

        /// <summary>
        ///     返回范围内随机int
        /// </summary>
        public static int NextInt(int min, int max)
        {
            return RandomV.Next(min, max);
        }

        /// <summary>
        ///     返回范围内随机float
        /// </summary>
        public static float NextFloat(float min, float max)
        {
            return (float)NextDouble(min, max);
        }

        /// <summary>
        ///     返回范围内随机double
        /// </summary>
        public static double NextDouble(double min, double max)
        {
            return RandomV.NextDouble() * (max - min) + min;
        }

        public static double NextDouble(double min, double max, int decimalPlace)
        {
            var randNum = RandomV.NextDouble() * (max - min) + min;
            return Convert.ToDouble(randNum.ToString("f" + decimalPlace));
        }

        public static T NextEnum<T>() where T : struct
        {
            var type = typeof(T);
            if (type.IsEnum == false) return default;
            var array = Enum.GetValues(type);
            var index = RandomV.Next(array.GetLowerBound(0), array.GetUpperBound(0) + 1);
            return (T)array.GetValue(index);
        }

        /// <summary>
        ///     返回范围内随机int
        /// </summary>
        public static int Next(int min, int max)
        {
            return RandomV.Next(min, max);
        }

        /// <summary>
        ///     返回范围内随机float
        /// </summary>
        public static float Next(float min, float max)
        {
            return (float)NextDouble(min, max);
        }

        /// <summary>
        ///     返回范围内随机double
        /// </summary>
        public static double Next(double min, double max)
        {
            return NextDouble(min, max);
        }

        public static string Next(string[] arr)
        {
            return arr[RandomV.Next(arr.Length - 1)];
        }

        /// <summary>
        ///     返回范围内随机int
        /// </summary>
        public static int NextIn(int a, int b)
        {
            return a < b ? Next(a, b) : Next(b, a);
        }

        /// <summary>
        ///     返回范围内随机float
        /// </summary>
        public static float NextIn(float a, float b)
        {
            return a < b ? Next(a, b) : Next(b, a);
        }

        /// <summary>
        ///     返回范围内随机double
        /// </summary>
        public static double NextIn(double a, double b)
        {
            return a < b ? Next(a, b) : Next(b, a);
        }

        public static int NextUnique(int min, int max)
        {
            lock (RandomV)
            {
                return RandomV.Next(min, max);
            }
        }

        public static float NextUnique(float min, float max)
        {
            lock (RandomV)
            {
                return Next(min, max);
            }
        }

        public static double NextUnique(double min, double max)
        {
            lock (RandomV)
            {
                return Next(min, max);
            }
        }

        public static IEnumerable<int> NextUniqueIntIList(int min, int max)
        {
            return Enumerable.Range(min, max).OrderBy(_ => Guid.NewGuid());
        }

        public static DateTime NextDateTime(DateTime minValue, DateTime maxValue)
        {
            var ticks = minValue.Ticks + (long)((maxValue.Ticks - minValue.Ticks) * RandomV.NextDouble());
            return new DateTime(ticks);
        }

        public static DateTime NextDateTime()
        {
            return NextDateTime(DateTime.MinValue, DateTime.MaxValue);
        }

        #endregion

        #endregion

        #region Tool

        /// <summary>
        ///     比较是否相等
        /// </summary>
        public static bool CompareTo<T>(T a, T b)
        {
            return a.Equals(b);
        }

        /// <summary>
        ///     字符串反转
        /// </summary>
        public static string Reverse(string value)
        {
            var input = value.ToCharArray();
            var output = new char[value.Length];
            var length = input.Length;
            for (var i = 0; i < length; i++)
                output[length - 1 - i] = input[i];
            return new string(output);
        }

        /// <summary>
        ///     整数反转
        /// </summary>
        public static int Reverse(long a)
        {
            if (a is > int.MaxValue or < int.MinValue) return 0;
            var temp = 0;
            while (a != 0)
            {
                var b = a % 10;
                a /= 10;
                temp = (int)(temp * 10 + b);
            }

            return temp;
        }

        /// <summary>
        ///     阶乘
        /// </summary>
        public static int Factorial(int n)
        {
            if (n <= 1) return n;
            var res = n;
            for (var i = 1; i < n; ++i) res *= i;
            return res;
        }

        /// <summary>
        ///     十进制转其它进制
        /// </summary>
        public static string DecimalConvert(int value, int converse)
        {
            return Convert.ToString(value, converse);
        }

        /// <summary>
        ///     其它进制转十进制
        /// </summary>
        public static int ConvertDecimal(string value, int converse)
        {
            return Convert.ToInt32(value, converse);
        }

        /// <summary>
        ///     整数转罗马数字
        /// </summary>
        public static string IntToRoman(long num)
        {
            var roman = new StringBuilder();
            foreach (var (value, symbol) in RomeNumeralSymbols)
            {
                while (num >= value)
                {
                    num -= value;
                    roman.Append(symbol);
                }

                if (num == 0) break;
            }

            return roman.ToString();
        }

        /// <summary>
        ///     罗马数字转整数
        /// </summary>
        public static int RomanToInt(string str)
        {
            var sum = 0;
            var preNum = GetRomeValue(str[0]);
            for (var i = 1; i < str.Length; i++)
            {
                var num = GetRomeValue(str[i]);
                if (preNum < num)
                    sum -= preNum;
                else
                    sum += preNum;
                preNum = num;
            }

            sum += preNum;
            return sum;
        }

        /// <summary>
        ///     字符串转整数
        /// </summary>
        public static int StringToInt(string str)
        {
            str = str.Trim();
            str = Regex.Match(str, @"^[+-]?\d+").ToString();
            var isParseSuccess = int.TryParse(str, out var num);
            if (isParseSuccess) return num;
            if (IsNullOrEmpty(str)) return 0;
            return str[0].Equals('-') ? int.MinValue : int.MaxValue;
        }

        /// <summary>
        ///     通配符匹配
        /// </summary>
        public static bool WildcardMatch(string s, string p)
        {
            int i = 0, j = 0, match = 0, star = -1;
            while (i < s.Length)
                switch (j - p.Length)
                {
                    case < 0 when s[i].Equals(p[j]) || p[j].Equals('?'):
                        i++;
                        j++;
                        break;
                    case < 0 when p[j].Equals('*'):
                        star = j++;
                        match = i;
                        break;
                    default:
                        if (star == -1) return false;
                        j = star + 1;
                        i = ++match;
                        break;
                }

            while (j < p.Length && p[j].Equals('*')) j++;
            return j == p.Length;
        }

        /// <summary>
        ///     Enum获取长度
        /// </summary>
        public static int Size<T>() where T : struct
        {
            var type = typeof(T);
            if (type.IsEnum == false) return -1;
            return Enum.GetValues(type).Length;
        }

        /// <summary>
        ///     旋转矩阵
        /// </summary>
        public static void RotateMatrix<T>(T[][] matrix)
        {
            var n = matrix.Length;
            for (var i = 0; i < n; i++)
                for (var j = 0; j < i; j++)
                    (matrix[i][j], matrix[j][i]) = (matrix[j][i], matrix[i][j]);
            for (var i = 0; i < n; i++)
                for (int j = 0, k = n - 1; j < k; j++, k--)
                    (matrix[i][k], matrix[i][j]) = (matrix[i][j], matrix[i][k]);
        }

        /// <summary>
        ///     格雷编码
        /// </summary>
        public static List<int> GrayCode(int n)
        {
            var ret = new List<int>();
            for (var i = 0; i < 1 << n; i++) ret.Add((i >> 1) ^ i);
            return ret;
        }

        /// <summary>
        ///     检查s2是否为s1的扰乱（顺序打乱）字符串
        /// </summary>
        public static bool IsScrambleString(string s1, string s2)
        {
            if (s1.Length != s2.Length) return false;
            var n = s1.Length;
            var dp = new bool[n, n, n];
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    dp[i, j, 0] = s1[i] == s2[j];
            for (var l = 1; l < n; l++)
                for (var i = 0; i < n - l; i++)
                    for (var j = 0; j < n - l; j++)
                        for (var w = 1; w < l + 1; w++)
                        {
                            dp[i, j, l] |= dp[i, j, w - 1] && dp[i + w, j + w, l - w];
                            dp[i, j, l] |= dp[i, j + l - w + 1, w - 1] && dp[i + w, j, l - w];
                            if (dp[i, j, l]) break;
                        }

            return dp[0, 0, n - 1];
        }

        /// <summary>
        ///     求每次只修改一个字符，将字符串转换成另一个字符串所使用的最少操作数
        /// </summary>
        public static int MinDistanceByTwoString(string word1, string word2)
        {
            var dp = new int[word2.Length + 1];
            for (var i = 0; i <= word1.Length; i++)
            {
                var leftUp = dp[0];
                dp[0] = i;
                for (var j = 1; j <= word2.Length; j++)
                    if (i == 0) dp[j] = j;
                    else
                        (dp[j], leftUp) = (
                            Min(Min(dp[j] + 1, dp[j - 1] + 1), leftUp + (word1[i - 1] == word2[j - 1] ? 0 : 1)), dp[j]);
            }

            return dp[word2.Length];
        }

        /// <summary>
        ///     检查字符串是否为有效数字
        /// </summary>
        public static bool IsValidNumber(string s)
        {
            static bool IsDigit(char c)
            {
                return c is >= '0' and <= '9';
            }

            if (IsNullOrEmpty(s)) return false;
            var index = 0;
            var digitCount = 0;
            while (index < s.Length && char.IsWhiteSpace(s[index])) ++index;
            if (index >= s.Length) return false;
            switch (s[index])
            {
                case '+':
                case '-':
                    ++index;
                    break;
                case '.':
                    ++index;
                    goto Dot;
            }

            while (index < s.Length && IsDigit(s[index]))
            {
                ++index;
                ++digitCount;
            }

            if (index >= s.Length) return digitCount > 0;
            switch (s[index])
            {
                case '.':
                    ++index;
                    goto Dot;
                case 'E':
                case 'e':
                    ++index;
                    goto Exp;
            }

            if (char.IsWhiteSpace(s[index])) goto Space;
            return false;
        Dot:
            while (index < s.Length && IsDigit(s[index]))
            {
                ++index;
                ++digitCount;
            }

            if (index >= s.Length) return digitCount > 0;
            switch (s[index])
            {
                case 'E':
                case 'e':
                    ++index;
                    goto Exp;
            }

            if (char.IsWhiteSpace(s[index])) goto Space;
            return false;
        Exp:
            if (index >= s.Length) return false;
            switch (s[index])
            {
                case '+':
                case '-':
                    ++index;
                    break;
            }

            if (index >= s.Length || !IsDigit(s[index])) return false;
            while (index < s.Length && IsDigit(s[index])) ++index;
            if (index >= s.Length) return digitCount > 0;
            if (char.IsWhiteSpace(s[index])) goto Space;
            return false;
        Space:
            while (index < s.Length && char.IsWhiteSpace(s[index])) ++index;
            return digitCount > 0 && index == s.Length;
        }

        /// <summary>
        ///     文本左右对齐
        /// </summary>
        public static List<string> TextFullJustify(string[] words, int maxWidth)
        {
            var n = words.Length;
            var nList = new int[n];
            var ans = new List<string>();
            for (var i = 0; i < n; i++) nList[i] = words[i].Length;
            var start = 0;
            var sLen = 0;
            for (var i = 0; i < n; i++)
            {
                sLen += nList[i] + 1;
                if (sLen == maxWidth || sLen - 1 == maxWidth)
                {
                    ans.Add(Rank(words, start, i, nList, maxWidth));
                    start = i + 1;
                    sLen = 0;
                }
                else if (sLen - 1 > maxWidth)
                {
                    ans.Add(Rank(words, start, i - 1, nList, maxWidth));
                    start = i;
                    sLen = nList[i] + 1;
                }
            }

            if (sLen != 0) ans.Add(Rank(words, start, n - 1, nList, maxWidth, true));
            return ans;

            static string Rank(IReadOnlyList<string> words, int start, int end, IReadOnlyList<int> nList, int maxvalue,
                bool last = false)
            {
                var st = Empty;
                if (last)
                {
                    for (var i = start; i < end; i++) st += words[i] + " ";
                    st += words[end];
                    while (st.Length != maxvalue) st += " ";
                }
                else
                {
                    var delta = end - start + 1;
                    if (delta == 1)
                    {
                        st = words[start];
                        while (st.Length != maxvalue) st += " ";
                        return st;
                    }

                    var nuns = 0;
                    for (var i = start; i <= end; i++) nuns += nList[i];
                    var k = maxvalue - nuns;
                    var mean = k / Max(delta - 1, 1);
                    var x = Empty;
                    for (var i = 0; i < mean; i++) x += " ";
                    var upk = k % Max(delta - 1, 1);
                    for (var i = 0; i < delta; i++)
                        if (i < upk)
                            st += words[i + start] + x + " ";
                        else if (i >= upk && i < delta - 1)
                            st += words[i + start] + x;
                        else
                            st += words[i + start];
                }

                return st;
            }
        }

        /// <summary>
        ///     反转英语句子
        /// </summary>
        public static string ReverseWords(string s)
        {
            return Join(" ",
                s.Trim().Split(" ").Where(word => !IsNullOrEmpty(word) && !IsNullOrEmpty(word.Trim()))
                    .Reverse());
        }

        /// <summary>
        ///     逆波兰表达式
        /// </summary>
        public static int ReversePolishNotation(string[] tokens)
        {
            var stack = new Stack<int>();
            var length = tokens.Length;
            for (var i = 0; i < length; i++)
            {
                var token = tokens[i];
                if (IsNumber(token))
                {
                    stack.Push(int.Parse(token));
                }
                else
                {
                    var num2 = stack.Pop();
                    var num1 = stack.Pop();
                    switch (token)
                    {
                        case "+":
                            stack.Push(num1 + num2);
                            break;
                        case "-":
                            stack.Push(num1 - num2);
                            break;
                        case "*":
                            stack.Push(num1 * num2);
                            break;
                        case "/":
                            stack.Push(num1 / num2);
                            break;
                    }
                }
            }

            return stack.Pop();

            static bool IsNumber(string token)
            {
                return char.IsDigit(token[^1]);
            }
        }

        /// <summary>
        ///     整数转英语单词
        /// </summary>
        public static string IntToEnglish(long num)
        {
            if (num == 0) return "Zero";
            var sb = new StringBuilder();
            for (int i = 3, unit = 1000000000; i >= 0; i--, unit /= 1000)
            {
                var curNum = num / unit;
                if (curNum == 0) continue;
                num -= curNum * unit;
                var cure = new StringBuilder();
                EnglishRecursion(cure, curNum);
                cure.Append(Thousands[i]).Append(" ");
                sb.Append(cure);
            }

            return sb.ToString().Trim();

            static void EnglishRecursion(StringBuilder cure, long num)
            {
                while (true)
                {
                    switch (num)
                    {
                        case 0:
                            return;
                        case < 10:
                            cure.Append(Singles[num]).Append(" ");
                            break;
                        case < 20:
                            cure.Append(Teens[num - 10]).Append(" ");
                            break;
                        case < 100:
                            cure.Append(Tens[num / 10]).Append(" ");
                            num %= 10;
                            continue;
                        default:
                            cure.Append(Singles[num / 100]).Append(" Hundred ");
                            num %= 100;
                            continue;
                    }

                    break;
                }
            }
        }

        /// <summary>
        ///     检查是否为同构字符串（t映射s）
        /// </summary>
        public static bool IsIsomorphicStrings(string s, string t)
        {
            var dic = new Dictionary<char, int>();
            var set = new HashSet<char>();
            for (var i = 0; i < s.Length; i++)
                if (!dic.ContainsKey(s[i]))
                {
                    if (!set.Contains(t[i]))
                        set.Add(t[i]);
                    else return false;
                    dic.Add(s[i], s[i] - t[i]);
                }
                else
                {
                    if (s[i] - t[i] != dic[s[i]]) return false;
                }

            return true;
        }

        /// <summary>
        ///     比特位计数
        /// </summary>
        public static int[] CountBits(int n)
        {
            var ans = new int[n + 1];
            for (int i = 1, highBit = 0; i <= n; i++)
            {
                if ((i & (i - 1)) == 0) highBit = i;
                ans[i] = ans[i - highBit] + 1;
            }

            return ans;
        }

        /// <summary>
        ///     获取int数组交集（连续相同元素子数组）
        /// </summary>
        public static int[] GetIntIntersect(int[] tempArray1, int[] tempArray2)
        {
            return tempArray1.Length <= tempArray2.Length
                ? GetIntersection(tempArray1, tempArray2)
                : GetIntersection(tempArray2, tempArray1);

            static int[] GetIntersection(IEnumerable<int> shorter, IEnumerable<int> longer)
            {
                IList<int> intersectionList = new List<int>();
                IDictionary<int, int> counts = new Dictionary<int, int>();
                foreach (var num in shorter)
                {
                    counts.TryAdd(num, 0);
                    counts[num]++;
                }

                foreach (var num in longer)
                    if (counts.ContainsKey(num))
                    {
                        intersectionList.Add(num);
                        counts[num]--;
                        if (counts[num] == 0) counts.Remove(num);
                    }

                return intersectionList.ToArray();
            }
        }

        /// <summary>
        ///     字符串Z型变换
        /// </summary>
        public static string ZConvert(string s, int numRows)
        {
            if (numRows == 1 || s.Length <= numRows) return s;
            var result = new StringBuilder();
            for (var i = 0; i < numRows; i++)
            {
                var startRound = (numRows - i - 1) * 2;
                var isSide = startRound == 0 || startRound == (numRows - 1) * 2;
                var location = i;
                var bol = true;
                while (true)
                {
                    result.Append(s[location]);
                    if (isSide)
                    {
                        location += (numRows - 1) * 2;
                    }
                    else
                    {
                        if (bol)
                        {
                            bol = false;
                            location += (numRows - i - 1) * 2;
                        }
                        else
                        {
                            bol = true;
                            location += i * 2;
                        }
                    }

                    if (location >= s.Length) break;
                }
            }

            return result.ToString();
        }

        /// <summary>
        ///     字符串用词典拆分成单词
        /// </summary>
        public static IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var record = new HashSet<int>();
            IList<string> res = new List<string>();
            var l = s.Length;
            const string temp = "";
            var dp = new bool[l + 1];
            foreach (var word in wordDict) record.Add(word.Length);
            dp[0] = true;
            Dfs(s, temp, wordDict, record, l, 0, dp);
            return res;

            void Dfs(string str, string inputTemp, IList<string> wordDic, HashSet<int> records, int len, int cur,
                IList<bool> deep)
            {
                for (var i = cur; i < len; i++)
                    if (deep[i])
                        foreach (var k in records)
                        {
                            if (i + k > len)
                                continue;
                            foreach (var word in wordDic)
                            {
                                var l2 = inputTemp.Length;
                                if (word.Length != k || word != str.Substring(i, k)) continue;
                                deep[i + k] = true;
                                inputTemp += word;
                                if (i + k == len)
                                {
                                    res.Add(inputTemp);
                                    inputTemp = inputTemp[..l2];
                                    continue;
                                }

                                inputTemp += " ";
                                Dfs(str, inputTemp, wordDic, records, len, i + k, deep);
                                inputTemp = inputTemp[..l2];
                                deep[i + k] = false;
                            }
                        }
            }
        }

        /// <summary>
        ///     给表达式添加运算符
        /// </summary>
        public static IList<string> AddOperators(string num, int target)
        {
            var n = num.Length;
            IList<string> ans = new List<string>();
            var expr = new StringBuilder();
            OperatorsBacktrack(expr, 0, 0, 0);
            return ans;

            void OperatorsBacktrack(StringBuilder exp, int i, long res, long mul)
            {
                if (i == n)
                {
                    if (res == target) ans.Add(exp.ToString());
                    return;
                }

                var signIndex = exp.Length;
                if (i > 0) exp.Append(0);
                long val = 0;
                for (var j = i; j < n && (j == i || num[i] != '0'); ++j)
                {
                    val = val * 10 + num[j] - '0';
                    exp.Append(num[j]);
                    if (i == 0)
                    {
                        OperatorsBacktrack(exp, j + 1, val, val);
                    }
                    else
                    {
                        exp.Replace(exp[signIndex], '+', signIndex, 1);
                        OperatorsBacktrack(exp, j + 1, res + val, val);
                        exp.Replace(exp[signIndex], '-', signIndex, 1);
                        OperatorsBacktrack(exp, j + 1, res - val, -val);
                        exp.Replace(exp[signIndex], '*', signIndex, 1);
                        OperatorsBacktrack(exp, j + 1, res - mul + mul * val, mul * val);
                    }
                }

                exp.Length = signIndex;
            }
        }

        /// <summary>
        ///     获取1-n之间，稳赢猜数字游戏需要的最小金钱
        /// </summary>
        public static int GetMoneyFingerGuessing(int n)
        {
            var f = new int[n + 1, n + 1];
            for (var i = n - 1; i >= 1; i--)
                for (var j = i + 1; j <= n; j++)
                {
                    f[i, j] = j + f[i, j - 1];
                    for (var k = i; k < j; k++) f[i, j] = Math.Min(f[i, j], k + Math.Max(f[i, k - 1], f[k + 1, j]));
                }

            return f[1, n];
        }

        /// <summary>
        ///     开启转盘锁最小旋转次数
        /// </summary>
        public static int FindRotateSteps(string ring, string key)
        {
            var ht = new Hashtable();
            for (var i = 0; i < ring.Length; i++)
                if (ht.ContainsKey(ring[i]))
                {
                    ((List<int>)ht[ring[i]]).Add(i);
                }
                else
                {
                    var list = new List<int> { i };
                    ht.Add(ring[i], list);
                }

            var steps = new int[ring.Length];
            for (var i = 0; i < steps.Length; i++) steps[i] = int.MaxValue;
            var list1 = (List<int>)ht[key[0]];
            foreach (var item in list1)
                steps[item] = Min(Abs(item - 0), ring.Length - Abs(item - 0));
            for (var i = 1; i < key.Length; i++)
            {
                var list = (List<int>)ht[key[i]];
                foreach (var item in list)
                {
                    var freelist = (List<int>)ht[key[i - 1]];
                    var stepTemp = freelist.Aggregate(int.MaxValue,
                        (current, preItem) => Min(current,
                            Min(Abs(item - preItem), ring.Length - Abs(item - preItem)) + steps[preItem]));
                    steps[item] = stepTemp;
                }
            }

            var list2 = (List<int>)ht[key[^1]];
            var minStep = list2.Aggregate(int.MaxValue, (current, item) => Min(current, steps[item]));
            return minStep + key.Length;
        }

        /// <summary>
        ///     重构字符串使相邻的字符不同
        /// </summary>
        public static string ReorganizeString(string s)
        {
            if (s.Length < 2) return s;
            var counts = new int[26];
            var maxCount = 0;
            var length = s.Length;
            for (var i = 0; i < length; i++)
            {
                var c = s[i];
                counts[c - 'a']++;
                maxCount = Max(maxCount, counts[c - 'a']);
            }

            if (maxCount > (length + 1) / 2) return "";
            var reorganizeArray = new char[length];
            int evenIndex = 0, oddIndex = 1;
            var halfLength = length / 2;
            for (var i = 0; i < 26; i++)
            {
                var c = (char)('a' + i);
                while (counts[i] > 0 && counts[i] <= halfLength && oddIndex < length)
                {
                    reorganizeArray[oddIndex] = c;
                    counts[i]--;
                    oddIndex += 2;
                }

                while (counts[i] > 0)
                {
                    reorganizeArray[evenIndex] = c;
                    counts[i]--;
                    evenIndex += 2;
                }
            }

            return new string(reorganizeArray);
        }

        /// <summary>
        ///     字符串按T标准自定义排序
        /// </summary>
        public static string CustomSortString(string s, string t)
        {
            var charS = new int[26];
            foreach (var c in t)
                charS[c - 'a']++;
            var temp = new StringBuilder();
            foreach (var c in s)
                while (charS[c - 'a'] > 0)
                {
                    temp.Append(c);
                    charS[c - 'a']--;
                }

            for (var i = 0; i < 26; i++)
                while (charS[i] > 0)
                {
                    temp.Append((char)(i + 'a'));
                    charS[i]--;
                }

            return temp.ToString();
        }

        /// <summary>
        ///     根据字符出现频率排序字符串
        /// </summary>
        public static string FrequencySortString(string s)
        {
            var dictionary = new Dictionary<char, int>();
            var length = s.Length;
            for (var i = 0; i < length; i++)
            {
                var c = s[i];
                if (dictionary.ContainsKey(c))
                    dictionary[c]++;
                else
                    dictionary.Add(c, 1);
            }

            var list = new List<char>(dictionary.Keys);
            list.Sort((a, b) => dictionary[b] - dictionary[a]);
            var sb = new StringBuilder();
            var size = list.Count;
            for (var i = 0; i < size; i++)
            {
                var c = list[i];
                var frequency = dictionary[c];
                for (var j = 0; j < frequency; j++) sb.Append(c);
            }

            return sb.ToString();
        }

        /// <summary>
        ///     获取字符串中相同字母重排列形成的所有字符串
        /// </summary>
        public static IList<int> FindStringAnagrams(string s, string p)
        {
            int sLen = s.Length, pLen = p.Length;
            if (sLen < pLen) return new List<int>();
            IList<int> ans = new List<int>();
            var count = new int[26];
            for (var i = 0; i < pLen; ++i)
            {
                ++count[s[i] - 'a'];
                --count[p[i] - 'a'];
            }

            var differ = 0;
            for (var j = 0; j < 26; ++j)
                if (count[j] != 0)
                    ++differ;
            if (differ == 0) ans.Add(0);
            for (var i = 0; i < sLen - pLen; ++i)
            {
                switch (count[s[i] - 'a'])
                {
                    case 1:
                        --differ;
                        break;
                    case 0:
                        ++differ;
                        break;
                }

                --count[s[i] - 'a'];
                switch (count[s[i + pLen] - 'a'])
                {
                    case -1:
                        --differ;
                        break;
                    case 0:
                        ++differ;
                        break;
                }

                ++count[s[i + pLen] - 'a'];
                if (differ == 0) ans.Add(i + 1);
            }

            return ans;
        }

        /// <summary>
        ///     检查是否能将一个数组分割成两个非空子数组，且两个子数组的平均值相等
        /// </summary>
        public static bool SplitArraySameAverage(int[] num)
        {
            if (num == null || num.Length < 2) return false;
            var total = num.Sum();
            if (total == 0) return true;
            var dp = new int[total];
            var n = num.Length;
            dp[0] = 1;
            for (var i = 0; i < n; i++)
                for (var j = total - 1; j >= num[i]; j--)
                {
                    dp[j] = dp[j] | (dp[j - num[i]] << 1);
                    if (j == 0) continue;
                    if (j * n % total == 0 && ((1 << (j * n / total)) & dp[j]) > 0)
                        return true;
                }

            return false;
        }

        /// <summary>
        ///     统计字符串中的唯一(只出现一次)字符个数
        /// </summary>
        public static int UniqueLetterString(string s)
        {
            var lastIndexMap = new int[26];
            var curIndexMap = new int[26];
            Collect.Fill(lastIndexMap, -1);
            Collect.Fill(curIndexMap, -1);
            var chars = s.ToCharArray();
            var ans = 0;
            for (var i = 0; i < chars.Length; i++)
            {
                var index = chars[i] - 'A';
                if (curIndexMap[index] > -1)
                    ans += (i - curIndexMap[index]) * (curIndexMap[index] - lastIndexMap[index]);
                lastIndexMap[index] = curIndexMap[index];
                curIndexMap[index] = i;
            }

            for (var i = 0; i < 26; i++)
                if (curIndexMap[i] > -1)
                    ans += (curIndexMap[i] - lastIndexMap[i]) * (s.Length - curIndexMap[i]);
            return ans;
        }

        /// <summary>
        ///     获取字符串中的相似字符串组数量
        /// </summary>
        public static int NumSimilarGroups(string[] str)
        {
            var n = str.Length;
            var m = str[0].Length;
            var f = new int[n];
            for (var i = 0; i < n; i++) f[i] = i;
            for (var i = 0; i < n; i++)
                for (var j = i + 1; j < n; j++)
                {
                    int fi = Find(i), fj = Find(j);
                    if (fi == fj) continue;
                    if (Check(str[i], str[j], m)) f[fi] = fj;
                }

            var ret = 0;
            for (var i = 0; i < n; i++)
                if (f[i] == i)
                    ret++;
            return ret;

            int Find(int x)
            {
                return f[x] == x ? x : f[x] = Find(f[x]);
            }

            bool Check(string a, string b, int len)
            {
                var num = 0;
                for (var i = 0; i < len; i++)
                    if (a[i] != b[i])
                    {
                        num++;
                        if (num > 2) return false;
                    }

                return true;
            }
        }

        /// <summary>
        ///     检查两个字符串每个字母出现频率之差是否小于delta
        /// </summary>
        public static bool StringEquivalent(string word1, string word2, int delta)
        {
            var cnt = new int[26];
            int m = word1.Length, n = word2.Length;
            if (m != n) return false;
            for (var i = 0; i < Max(m, n); ++i)
            {
                var idx1 = word1[i] - 'a';
                var idx2 = word2[i] - 'a';
                if (i < m) ++cnt[idx1];
                if (i < n) --cnt[idx2];
            }

            for (var i = 0; i < 26; ++i)
                if (cnt[i] > delta || cnt[i] < -delta)
                    return false;
            return true;
        }

        /// <summary>
        ///     寻找连续整数中缺失的数
        /// </summary>
        public static int FindMissNumber(int[] num)
        {
            var n = num.Length;
            var total = n * (n + 1) / 2;
            var arrSum = 0;
            for (var i = 0; i < n; ++i) arrSum += num[i];
            return total - arrSum;
        }

        /// <summary>
        ///     随机分割整数num成大于0的k份
        /// </summary>
        public static List<int> SplitInt(int num, int k)
        {
            if (k > num) return default;
            var temp = new List<int>();
            for (var i = 0; i < k - 1; ++i)
            {
                var tempNum = RandomV.Next(1, num - k + i + 1);
                temp.Add(tempNum);
                num -= tempNum;
            }

            temp.Add(num);
            return temp;
        }

        /// <summary>
        ///     检查两个容量分别为a,b的水壶，是否能装出t的水
        /// </summary>
        public static bool CheckJugCapacity(int a, int b, int t)
        {
            if (a + b < t) return false;
            return t % Gcd(a, b) == 0;

            static int Gcd(int num1, int num2)
            {
                while (num2 != 0)
                {
                    var temp = num1;
                    num1 = num2;
                    num2 = temp % num2;
                }

                return num1;
            }
        }

        /// <summary>
        ///     UTF-8 编码验证
        /// </summary>
        public static bool ValidUtf8(int[] data)
        {
            var m = data.Length;
            var index = 0;
            while (index < m)
            {
                var num = data[index];
                var n = GetBytes(num);
                if (n < 0 || index + n > m) return false;
                for (var i = 1; i < n; i++)
                    if (!IsValid(data[index + i]))
                        return false;
                index += n;
            }

            return true;

            int GetBytes(int num)
            {
                if ((num & Mask1) == 0) return 1;
                var n = 0;
                var mask = Mask1;
                while ((num & mask) != 0)
                {
                    n++;
                    if (n > 4) return -1;
                    mask >>= 1;
                }

                return n >= 2 ? n : -1;
            }

            bool IsValid(int num)
            {
                return (num & Mask2) == Mask1;
            }
        }

        /// <summary>
        ///     十进制整数的反码对应的整数
        /// </summary>
        public static int BitwiseInverseInt(int n)
        {
            var sum = 1;
            while (sum < n) sum = sum * 2 + 1;
            return sum - n;
        }

        /// <summary>
        ///     最少试毒小猪
        /// </summary>
        public static int PoorPigs(int buckets, int minutesToDie, int minutesToTest)
        {
            var states = minutesToTest / minutesToDie + 1;
            var pigs = (int)Math.Ceiling(Log(buckets) / Log(states) - 1e-5);
            return pigs;
        }

        /// <summary>
        ///     密钥格式化
        /// </summary>
        public static string LicenseKeyFormatting(string s, int k)
        {
            var sb = new StringBuilder();
            var cnt = 0;
            for (var i = s.Length - 1; i >= 0; i--)
                if (s[i] != '-')
                {
                    cnt++;
                    sb.Append(char.ToUpper(s[i]));
                    if (cnt % k == 0) sb.Append("-");
                }

            if (sb.Length > 0 && sb[^1] == '-') sb.Remove(sb.Length - 1, 1);
            var cs = sb.ToString().ToCharArray();
            Array.Reverse(cs);
            return new string(cs);
        }

        /// <summary>
        ///     单词的压缩编码
        /// </summary>
        public static int ValidWordEncoding(string[] words)
        {
            var set = new HashSet<string>(words);
            foreach (var t in words)
                for (var j = 1; j < t.Length; j++)
                    set.Remove(t[j..]);
            return set.Sum(item => item.Length + 1);
        }

        /// <summary>
        ///     负二进制转换
        /// </summary>
        public static string BaseNeg2(int n)
        {
            if (n == 0) return "0";
            var sb = new StringBuilder();
            while (n != 0)
            {
                var remainder = Abs(n) % -2;
                sb.Append(remainder);
                n -= remainder;
                n /= -2;
            }

            var sb2 = new StringBuilder();
            for (var i = sb.Length - 1; i >= 0; i--) sb2.Append(sb[i]);
            return sb2.ToString();
        }

        /// <summary>
        ///     二进制加法
        /// </summary>
        public static string BinaryAddition(string a, string b)
        {
            int len1 = a.Length, len2 = b.Length;
            var len = Math.Max(len1, len2);
            var arr = new char[len];
            var extra = 0;
            for (int i = len1 - 1, j = len2 - 1, k = len - 1; k >= 0; --k)
            {
                var num1 = i >= 0 ? a[i--] - '0' : 0;
                var num2 = j >= 0 ? b[j--] - '0' : 0;
                var num = num1 + num2 + extra;
                extra = num / 2;
                num %= 2;
                arr[k] = (char)(num + '0');
            }

            var ans = new string(arr);
            if (extra > 0) return "1" + ans;
            return ans;
        }

        /// <summary>
        ///     m*n网格从左上角到右下角的路径总数
        /// </summary>
        public static int UniquePaths(int m, int n)
        {
            long ans = 1;
            for (int x = n, y = 1; y < m; ++x, ++y) ans = ans * x / y;
            return (int)ans;
        }

        /// <summary>
        ///     字符串s替换m成n
        /// </summary>
        public static string StringReplace(string s, char m, string n)
        {
            var str = new StringBuilder();
            foreach (var t in s)
                if (t.Equals(m))
                    str.Append(n);
                else
                    str.Append(t);
            return str.ToString();
        }

        /// <summary>
        ///     转置矩阵（横纵交换）
        /// </summary>
        public static T[][] TransposeMatrix<T>(T[][] matrix)
        {
            int m = matrix.Length, n = matrix[0].Length;
            var transposed = new T[n][];
            for (var i = 0; i < n; i++) transposed[i] = new T[m];
            for (var i = 0; i < m; i++)
                for (var j = 0; j < n; j++)
                    transposed[j][i] = matrix[i][j];
            return transposed;
        }

        /// <summary>
        ///     解压缩编码列表
        /// </summary>
        public static int[] DecompressEncodeList(int[] num)
        {
            var list = new List<int>();
            for (var i = 0; i < num.Length; i += 2)
            {
                var freq = num[i];
                var val = num[i + 1];
                for (var j = 0; j < freq; j++) list.Add(val);
            }

            var res = list.ToArray();
            return res;
        }

        /// <summary>
        ///     求时钟的时针和分针的夹角
        /// </summary>
        public static double AngleClock(int hour, int minutes)
        {
            var degree = Abs(hour * 30 - minutes * 5.5);
            return Min(degree, 360 - degree);
        }

        /// <summary>
        ///     日期格式转化，例：20th Oct 2052——2052-10-20
        /// </summary>
        public static string ReformatDate(string date)
        {
            var dateArr = date.Split(" ");
            var sb = new StringBuilder();
            sb.Append(dateArr[2] + "-");
            sb.Append(Date[dateArr[1]] + "-");
            var day = dateArr[0].Length == 3 ? "0" + dateArr[0][..1] : dateArr[0][..2];
            sb.Append(day);
            return sb.ToString();
        }

        /// <summary>
        ///     千位分割int
        /// </summary>
        public static string ThousandSeparator(long n)
        {
            var s = n.ToString();
            var res = new StringBuilder();
            var count = 0;
            for (var i = s.Length - 1; i >= 0; --i)
            {
                count++;
                res.Insert(0, s[i]);
                if (count != 3 || i <= 0) continue;
                count = 0;
                res.Insert(0, " ");
            }

            return res.ToString();
        }

        /// <summary>
        ///     同源字符串检测
        /// </summary>
        public static bool PossiblyEquals(string s1, string s2)
        {
            int s1Len = s1.Length, s2Len = s2.Length;
            var dp = new HashSet<int>[s1Len + 1, s2Len + 1];
            for (var i = 0; i <= s1Len; ++i)
                for (var j = 0; j <= s2Len; ++j)
                    dp[i, j] = new HashSet<int>();
            dp[0, 0].Add(0);
            for (var i = 0; i <= s1Len; ++i)
                for (var j = 0; j <= s2Len; ++j)
                    foreach (var item in dp[i, j])
                    {
                        if (item == 0 && i < s1Len && j < s2Len && s1[i] == s2[j] && s1[i] >= 'a') dp[i + 1, j + 1].Add(0);
                        var sum = 0;
                        var k = j;
                        while (k < s2Len && s2[k] < 'a')
                        {
                            sum = 10 * sum + s2[k] - '0';
                            dp[i, k + 1].Add(item - sum);
                            ++k;
                        }

                        sum = 0;
                        k = i;
                        while (k < s1Len && s1[k] < 'a')
                        {
                            sum = 10 * sum + s1[k] - '0';
                            dp[k + 1, j].Add(item + sum);
                            ++k;
                        }

                        switch (item)
                        {
                            case > 0 when j < s2Len && s2[j] >= 'a':
                                dp[i, j + 1].Add(item - 1);
                                break;
                            case < 0 when i < s1Len && s1[i] >= 'a':
                                dp[i + 1, j].Add(item + 1);
                                break;
                        }
                    }

            return dp[s1Len, s2Len].Contains(0);
        }

        /// <summary>
        ///     将标题首字母大写
        /// </summary>
        public static string CapitalizeTitle(string title)
        {
            var c = title.ToCharArray();
            var len = c.Length;
            var first = 0;
            var count = 0;
            for (var i = 0; i < len; i++)
            {
                if (c[i] == ' ')
                {
                    if (count > 2) c[first] = (char)(c[first] - 32);
                    count = 0;
                    first = i + 1;
                }
                else
                {
                    count++;
                    if (c[i] < 'a') c[i] = (char)(c[i] + 32);
                }

                if (i == len - 1 && count > 2) c[first] = (char)(c[first] - 32);
            }

            return new string(c);
        }

        /// <summary>
        ///     向字符串添加空格
        /// </summary>
        public static string AddSpacesToString(string s, int[] spaces)
        {
            var idx = 0;
            var sb = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {
                if (idx < spaces.Length && i == spaces[idx])
                {
                    sb.Append(' ');
                    idx++;
                }

                sb.Append(s[i]);
            }

            return sb.ToString();
        }

        /// <summary>
        ///     强密码校验器
        /// </summary>
        public static bool StrongPasswordVerifier(string password)
        {
            const string ap = "!@#$%^&*()-+";
            var n = password.Length;
            if (n < 8) return false;
            bool hasBelt, hasDit, hasAp;
            var hasMelt = hasBelt = hasDit = hasAp = false;
            for (var i = 0; i < n; i++)
            {
                var c = password[i];
                if (i > 0 && c == password[i - 1]) return false;
                if (char.IsDigit(c))
                    hasDit = true;
                else
                    switch (c)
                    {
                        case >= 'a' and <= 'z':
                            hasMelt = true;
                            break;
                        case >= 'A' and <= 'Z':
                            hasBelt = true;
                            break;
                        default:
                            {
                                if (ap.Any(t => t == c)) hasAp = true;
                                break;
                            }
                    }
            }

            return hasMelt && hasAp && hasDit && hasBelt;
        }

        /// <summary>
        ///     交替合并字符串
        /// </summary>
        public static string AlternateMergeStrings(string word1, string word2)
        {
            StringBuilder sb = new();
            var len = Math.Max(word1.Length, word2.Length);
            for (var i = 0; i < len; i++)
            {
                if (i < word1.Length)
                    sb.Append(word1[i]);
                if (i < word2.Length)
                    sb.Append(word2[i]);
            }

            return sb.ToString();
        }

        /// <summary>
        ///     无重复字符的最长子串
        /// </summary>
        public static int LengthOfLongestSubstring(string s)
        {
            var letter = new HashSet<char>();
            int left = 0, right = 0;
            var length = s.Length;
            int count = 0, max = 0;
            while (right < length)
            {
                if (!letter.Contains(s[right]))
                {
                    letter.Add(s[right]);
                    right++;
                    count++;
                }
                else
                {
                    letter.Remove(s[left]);
                    left++;
                    count--;
                }

                max = Math.Max(max, count);
            }

            return max;
        }

        /// <summary>
        ///     n*n网格上放正方体，组合成的三维形体的表面积
        /// </summary>
        public static int SurfaceArea(int[][] grid)
        {
            int n = grid.Length, area = 0;
            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                {
                    var level = grid[i][j];
                    if (level <= 0) continue;
                    area += (level << 2) + 2;
                    area -= i > 0 ? Min(level, grid[i - 1][j]) << 1 : 0;
                    area -= j > 0 ? Min(level, grid[i][j - 1]) << 1 : 0;
                }

            return area;
        }

        /// <summary>
        ///     获取菱形面积
        /// </summary>
        private static int GetLenSquare(IReadOnlyList<int> point1, IReadOnlyList<int> point2)
        {
            return (point2[0] - point1[0]) * (point2[0] - point1[0]) +
                   (point2[1] - point1[1]) * (point2[1] - point1[1]);
        }

        /// <summary>
        ///     判断4个坐标连线是否为有效正方形
        /// </summary>
        public static bool ValidSquare(int[] p1, int[] p2, int[] p3, int[] p4)
        {
            var set = new HashSet<int>
            {
                GetLenSquare(p1, p2),
                GetLenSquare(p1, p3),
                GetLenSquare(p1, p4),
                GetLenSquare(p2, p3),
                GetLenSquare(p2, p4),
                GetLenSquare(p3, p4)
            };
            return set.All(x => x != 0) && set.Count == 2;
        }

        #endregion

        #region Array & List

        #region Array

        #region Specific

        /// <summary>
        ///     二分查找
        /// </summary>
        public static int BinarySearch(int[] intArray, int target)
        {
            var lower = 0;
            var upper = intArray.Length - 1;
            while (lower <= upper)
            {
                var middleIndex = (lower + upper) / 2;
                if (target == intArray[middleIndex])
                    return middleIndex;
                if (target < intArray[middleIndex])
                    upper = middleIndex - 1;
                else
                    lower = middleIndex + 1;
            }

            if (target == intArray[lower])
                return lower;
            return -1;
        }

        /// <summary>
        ///     String使用分隔符转String数组
        /// </summary>
        public static string[] StringSplit(string input, string splitSign)
        {
            return input.Split(splitSign);
        }

        /// <summary>
        ///     获取每一位数
        /// </summary>
        public static int[] GetEveryNumber(int value)
        {
            var numbers = new Stack<int>();
            for (; value > 0; value /= 10) numbers.Push(value % 10);
            return numbers.ToArray();
        }

        #endregion

        #region Common

        /// <summary>
        ///     元素交换
        /// </summary>
        public static T[] Swap<T>(T[] arr, int i, int j)
        {
            if (i < arr.Length && j < arr.Length && i >= 0 && j >= 0)
                (arr[i], arr[j]) = (arr[j], arr[i]);
            return arr;
        }

        /// <summary>
        ///     反转
        /// </summary>
        public static T[] Reverse<T>(T[] value)
        {
            var length = value.Length;
            var output = new T[length];
            for (var i = 0; i < length; i++)
                output[length - 1 - i] = value[i];
            return output;
        }

        /// <summary>
        ///     全排序
        /// </summary>
        public static IList<IList<T>> Permute<T>(T[] tempArray)
        {
            IList<IList<T>> res = new List<IList<T>>();
            Backtracking(tempArray, new List<T>(), res);

            static void Backtracking(IReadOnlyCollection<T> nuns, IList<T> path, ICollection<IList<T>> res)
            {
                if (path.Count == nuns.Count)
                {
                    res.Add(new List<T>(path));
                    return;
                }

                foreach (var t in nuns)
                    if (!path.Contains(t))
                    {
                        path.Add(t);
                        Backtracking(nuns, path, res);
                        path.RemoveAt(path.Count - 1);
                    }
            }

            return res;
        }

        /// <summary>
        ///     不重复全排序
        /// </summary>
        public static IList<IList<T>> PermuteUnique<T>(T[] input)
        {
            IList<IList<T>> tempList = new List<IList<T>>();
            var nes = new List<T>();
            Array.Sort(input);
            var isUsed = new bool[input.Length];
            BackTrack(input, isUsed);
            return tempList;

            void BackTrack(IReadOnlyList<T> nuns, IList<bool> isUed)
            {
                if (nuns.Count == nes.Count)
                {
                    tempList.Add(new List<T>(nes));
                    return;
                }

                for (var i = 0; i < nuns.Count; i++)
                {
                    if (i > 0 && nuns[i].Equals(nuns[i - 1]) && isUed[i - 1] == false)
                        continue;
                    if (isUed[i]) continue;
                    isUed[i] = true;
                    nes.Add(nuns[i]);
                    BackTrack(nuns, isUed);
                    nes.RemoveAt(nes.Count - 1);
                    isUed[i] = false;
                }
            }
        }

        /// <summary>
        ///     随机分割成k份
        /// </summary>
        public static List<List<T>> RandomSplit<T>(T[] temp, int k)
        {
            return RandomSplit(temp.ToList(), k);
        }

        /// <summary>
        ///     找中间值
        /// </summary>
        public static double FindMedian(int[] tempArray)
        {
            var length = tempArray.Length;
            if (length == 0) return 0;
            var id = length / 2;
            return length % 2 == 0 ? (double)(tempArray[id] + tempArray[id - 1]) / 2 : tempArray[id];
        }

        /// <summary>
        ///     找中间值
        /// </summary>
        public static double FindMedian(float[] tempArray)
        {
            var length = tempArray.Length;
            if (length == 0) return 0;
            var id = length / 2;
            return length % 2 == 0 ? (double)(tempArray[id] + tempArray[id - 1]) / 2 : tempArray[id];
        }

        /// <summary>
        ///     找中间值
        /// </summary>
        public static double FindMedian(double[] tempArray)
        {
            var length = tempArray.Length;
            if (length == 0) return 0;
            var id = length / 2;
            return length % 2 == 0 ? (tempArray[id] + tempArray[id - 1]) / 2 : tempArray[id];
        }

        /// <summary>
        ///     求平均数
        /// </summary>
        public static int GetAverage(int[] tempList)
        {
            return (int)tempList.Average();
        }

        /// <summary>
        ///     求平均数
        /// </summary>
        public static float GetAverage(float[] tempList)
        {
            return tempList.Average();
        }

        /// <summary>
        ///     String数组转int数组
        /// </summary>
        public static int[] StringToInt(string[] input)
        {
            var temp = Array.ConvertAll(input, s => int.TryParse(s, out var i) ? i : ' ');
            return temp;
        }

        /// <summary>
        ///     String数组转float数组
        /// </summary>
        public static float[] StringToFloat(string[] input)
        {
            var temp = Array.ConvertAll(input, s => float.TryParse(s, out var i) ? i : ' ');
            return temp;
        }

        /// <summary>
        ///     获取int相邻差值绝对值最小的数对列表
        /// </summary>
        public static List<int> FindClosestPairIndex(int[] inputArray)
        {
            return FindClosestPairIndex(inputArray.ToList());
        }

        /// <summary>
        ///     获取float相邻差值绝对值最小的数对列表
        /// </summary>
        public static List<int> FindClosestPairIndex(float[] inputArray)
        {
            return FindClosestPairIndex(inputArray.ToList());
        }

        /// <summary>
        ///     获取Id
        /// </summary>
        public static int GetId<T>(T[] tempArray, T temp)
        {
            var length = tempArray.Length;
            for (var i = 0; i < length; ++i)
                if (tempArray[i].Equals(temp))
                    return i;
            return -1;
        }

        /// <summary>
        ///     正向（从小到大）排序
        /// </summary>
        public static T[] ContinueSort<T>(T[] tempArray)
        {
            return ContinueSort(tempArray.ToList()).ToArray();
        }

        /// <summary>
        ///     反向（从大到小）排序
        /// </summary>
        public static T[] ReverseSort<T>(T[] tempArray)
        {
            return ReverseSort(tempArray.ToList()).ToArray();
        }

        /// <summary>
        ///     浅层克隆
        /// </summary>
        public static T[] Clone<T>(T[] tempArray)
        {
            return tempArray;
        }

        /// <summary>
        ///     浅层复制
        /// </summary>
        public static T[] Copy<T>(T[] tempArray)
        {
            return Copy(tempArray.ToList()).ToArray();
        }

        /// <summary>
        ///     随机抽取出一个新的数组
        /// </summary>
        public static T[] RandomDrawInit<T>(T[] tempArray, int num)
        {
            return RandomDrawInit(tempArray.ToList(), num).ToArray();
        }

        /// <summary>
        ///     从顶部抽取出一个新的数组
        /// </summary>
        public static T[] TopDrawInit<T>(T[] tempArray, int num)
        {
            return TopDrawInit(tempArray.ToList(), num).ToArray();
        }

        /// <summary>
        ///     从底部抽取出一个新的数组
        /// </summary>
        public static T[] BottomDrawInit<T>(T[] tempArray, int num)
        {
            return BottomDrawInit(tempArray.ToList(), num).ToArray();
        }

        /// <summary>
        ///     打乱
        /// </summary>
        public static T[] Shuffle<T>(T[] tempArray)
        {
            var length = tempArray.Length;
            var temp = Copy(tempArray);
            for (var i = 0; i < length; ++i)
            {
                var j = RandomV.Next(i, length);
                (temp[i], temp[j]) = (temp[j], temp[i]);
            }

            return temp;
        }

        /// <summary>
        ///     移动指定位数(轮转)
        /// </summary>
        public static T[] RotateMove<T>(T[] tempArray, int move)
        {
            var length = tempArray.Length;
            var newArray = new T[length];
            var newIndex = length - move % length;
            for (var i = 0; i < length; ++i) newArray[i] = tempArray[(newIndex + i) % length];
            return newArray;
        }

        /// <summary>
        ///     查询含有
        /// </summary>
        public static bool ContainsCheck<T>(T[] tempArray, T temp)
        {
            return ContainsCheck(tempArray.ToList(), temp);
        }

        /// <summary>
        ///     查重
        /// </summary>
        public static bool DuplicateCheck<T>(T[] tempArray)
        {
            var set = new HashSet<T>();
            return tempArray.Any(x => !set.Add(x));
        }

        /// <summary>
        ///     获取重复元素
        /// </summary>
        public static T[] FindDuplicates<T>(T[] tempArray)
        {
            IList<T> temp = new List<T>();
            var hash = new HashSet<T>();
            foreach (var t in tempArray)
                if (hash.Contains(t))
                    temp.Add(t);
                else
                    hash.Add(t);
            return temp.ToArray();
        }

        /// <summary>
        ///     组去重
        /// </summary>
        public static T[] GroupDistinct<T>(T[] array)
        {
            return array.GroupBy(p => p).Select(p => p.Key).ToArray();
        }

        /// <summary>
        ///     Linq去重
        /// </summary>
        public static T[] Distinct<T>(T[] tempArray)
        {
            return tempArray.Distinct().ToArray();
        }

        /// <summary>
        ///     遍历去重
        /// </summary>
        public static T[] LoopDistinct<T>(T[] tempArray)
        {
            return LoopDistinct(tempArray.ToList()).ToArray();
        }

        /// <summary>
        ///     哈希去重
        /// </summary>
        public static T[] HashDistinct<T>(T[] tempArray)
        {
            return HashDistinct(tempArray.ToList()).ToArray();
        }

        #endregion

        #endregion

        #region List

        #region Common

        /// <summary>
        ///     元素交换
        /// </summary>
        public static List<T> Swap<T>(List<T> tempList, int i, int j)
        {
            if (i < tempList.Count && j < tempList.Count && i >= 0 && j >= 0)
                (tempList[i], tempList[j]) = (tempList[j], tempList[i]);
            return tempList;
        }

        /// <summary>
        ///     反转
        /// </summary>
        public static List<T> Reverse<T>(List<T> value)
        {
            return Reverse(value.ToArray()).ToList();
        }

        /// <summary>
        ///     全排序
        /// </summary>
        public static IList<IList<T>> Permute<T>(List<T> tempList)
        {
            return Permute(tempList.ToArray());
        }

        /// <summary>
        ///     不重复全排序
        /// </summary>
        public static IList<IList<T>> PermuteUnique<T>(List<T> input)
        {
            return PermuteUnique(input.ToArray());
        }

        /// <summary>
        ///     随机分割成k份
        /// </summary>
        public static List<List<T>> RandomSplit<T>(List<T> temp, int k)
        {
            if (temp.Count < k) return default;
            var num = SplitInt(temp.Count, k);
            return num.Select(t => RandomDrawInit(temp, t)).ToList();
        }

        /// <summary>
        ///     找中间值
        /// </summary>
        public static double FindMedian(List<int> tempList)
        {
            var count = tempList.Count;
            if (count == 0) return 0;
            var id = count / 2;
            return count % 2 == 0 ? (double)(tempList[id] + tempList[id - 1]) / 2 : tempList[id];
        }

        /// <summary>
        ///     找中间值
        /// </summary>
        public static double FindMedian(List<float> tempList)
        {
            var count = tempList.Count;
            if (count == 0) return 0;
            var id = count / 2;
            return count % 2 == 0 ? (double)(tempList[id] + tempList[id - 1]) / 2 : tempList[id];
        }

        /// <summary>
        ///     找中间值
        /// </summary>
        public static double FindMedian(List<double> tempList)
        {
            var count = tempList.Count;
            if (count == 0) return 0;
            var id = count / 2;
            return count % 2 == 0 ? (tempList[id] + tempList[id - 1]) / 2 : tempList[id];
        }

        /// <summary>
        ///     求平均数
        /// </summary>
        public static int GetAverage(List<int> tempList)
        {
            return (int)tempList.Average();
        }

        /// <summary>
        ///     求平均数
        /// </summary>
        public static float GetAverage(List<float> tempList)
        {
            return tempList.Average();
        }

        /// <summary>
        ///     String列表转int列表
        /// </summary>
        public static List<int> StringToInt(List<string> input)
        {
            return StringToInt(input.ToArray()).ToList();
        }

        /// <summary>
        ///     String列表转float列表
        /// </summary>
        public static List<float> StringToFloat(List<string> input)
        {
            return StringToFloat(input.ToArray()).ToList();
        }

        /// <summary>
        ///     获取int相邻差值绝对值最小的数对列表
        /// </summary>
        public static List<int> FindClosestPairIndex(List<int> inputList)
        {
            var tempList = new List<int>();
            var minDelta = Abs(inputList[0] - inputList[1]);
            for (int i = 1, count = inputList.Count - 1; i < count; ++i)
            {
                int temp;
                if (minDelta < (temp = Abs(inputList[i] - inputList[i + 1]))) continue;
                minDelta = temp;
                tempList.Add(i);
            }

            return tempList;
        }

        /// <summary>
        ///     获取float相邻差值绝对值最小的数对列表
        /// </summary>
        public static List<int> FindClosestPairIndex(List<float> inputList)
        {
            var tempList = new List<int>();
            var minDelta = Abs(inputList[0] - inputList[1]);
            for (int i = 1, length = inputList.Count - 1; i < length; ++i)
            {
                float temp;
                if (minDelta < (temp = Abs(inputList[i] - inputList[i + 1]))) continue;
                minDelta = temp;
                tempList.Add(i);
            }

            return tempList;
        }

        /// <summary>
        ///     获取Id
        /// </summary>
        public static int GetId<T>(List<T> tempList, T temp)
        {
            return GetId(tempList.ToArray(), temp);
        }

        /// <summary>
        ///     正向（从小到大）排序
        /// </summary>
        public static List<T> ContinueSort<T>(List<T> tempList)
        {
            var newList = new List<T>(tempList);
            newList.Sort();
            return newList;
        }

        /// <summary>
        ///     反向（从大到小）排序
        /// </summary>
        public static List<T> ReverseSort<T>(List<T> tempList)
        {
            var newList = new List<T>(tempList);
            newList.Sort();
            newList.Reverse();
            return newList;
        }

        /// <summary>
        ///     浅层克隆
        /// </summary>
        public static List<T> Clone<T>(List<T> tempList)
        {
            return tempList;
        }

        /// <summary>
        ///     浅层复制
        /// </summary>
        public static List<T> Copy<T>(List<T> tempList)
        {
            return new List<T>(tempList);
        }

        /// <summary>
        ///     随机抽取出一个新的列表
        /// </summary>
        public static List<T> RandomDrawInit<T>(List<T> tempList, int num)
        {
            var temp = new List<T>();
            var oldTemp = Copy(tempList);
            var count = tempList.Count;
            for (var i = 0; i < num; ++i)
            {
                if (count <= 0) break;
                var j = RandomV.Next(0, count);
                temp.Add(oldTemp[j]);
                oldTemp.RemoveAt(j);
                --count;
            }

            return temp;
        }

        /// <summary>
        ///     从顶部抽取出一个新的列表
        /// </summary>
        public static List<T> TopDrawInit<T>(List<T> tempList, int num)
        {
            var temp = new List<T>();
            var oldTemp = Copy(tempList);
            var count = tempList.Count;
            for (var i = 0; i < num; ++i)
            {
                if (count <= 0) break;
                temp.Add(oldTemp[0]);
                oldTemp.RemoveAt(0);
                --count;
            }

            return temp;
        }

        /// <summary>
        ///     从底部抽取出一个新的列表
        /// </summary>
        public static List<T> BottomDrawInit<T>(List<T> tempList, int num)
        {
            var temp = new List<T>();
            var oldTemp = Copy(tempList);
            var count = tempList.Count;
            for (var i = 0; i < num; ++i)
            {
                if (count <= 0) break;
                temp.Add(oldTemp[^1]);
                oldTemp.RemoveAt(oldTemp.Count - 1);
                --count;
            }

            return temp;
        }

        /// <summary>
        ///     打乱
        /// </summary>
        public static List<T> Shuffle<T>(List<T> tempList)
        {
            var count = tempList.Count;
            var temp = Copy(tempList);
            for (var i = 0; i < count; ++i)
            {
                var j = RandomV.Next(i, count);
                (temp[i], temp[j]) = (temp[j], temp[i]);
            }

            return temp;
        }

        /// <summary>
        ///     移动指定位数(轮转)
        /// </summary>
        public static List<T> RotateMove<T>(List<T> tempList, int move)
        {
            return RotateMove(tempList.ToArray(), move).ToList();
        }

        /// <summary>
        ///     查询含有
        /// </summary>
        public static bool ContainsCheck<T>(List<T> tempList, T temp)
        {
            return tempList.Contains(temp);
        }

        /// <summary>
        ///     查重
        /// </summary>
        public static bool DuplicateCheck<T>(List<T> tempList)
        {
            return DuplicateCheck(tempList.ToArray());
        }

        /// <summary>
        ///     获取重复元素
        /// </summary>
        public static List<T> FindDuplicates<T>(List<T> tempList)
        {
            IList<T> temp = new List<T>();
            var hash = new HashSet<T>();
            foreach (var t in tempList)
                if (hash.Contains(t))
                    temp.Add(t);
                else
                    hash.Add(t);
            return temp.ToList();
        }

        /// <summary>
        ///     组去重
        /// </summary>
        public static List<T> GroupDistinct<T>(List<T> tempList)
        {
            return tempList.GroupBy(p => p).Select(p => p.Key).ToList();
        }

        /// <summary>
        ///     Linq去重
        /// </summary>
        public static List<T> Distinct<T>(List<T> tempList)
        {
            return tempList.Distinct().ToList();
        }

        /// <summary>
        ///     遍历去重
        /// </summary>
        public static List<T> LoopDistinct<T>(List<T> tempList)
        {
            var newList = new List<T>(tempList);
            for (var i = 0; i < newList.Count; ++i)
                for (var j = newList.Count - 1; j > i; --j)
                    if (newList[i].Equals(newList[j]))
                        newList.RemoveAt(j);
            return newList;
        }

        /// <summary>
        ///     哈希去重
        /// </summary>
        public static List<T> HashDistinct<T>(List<T> tempList)
        {
            var set = new HashSet<T>();
            var temp = new List<T>();
            foreach (var t in tempList.Where(t => !set.Contains(t)))
            {
                set.Add(t);
                temp.Add(t);
            }

            return temp;
        }

        #endregion

        #endregion

        #endregion
    }

    #endregion

    #region Core

    /// <summary>
    ///     基本单位
    /// </summary>
    public struct Utility : IEquatable<Utility>, IComparable<Utility>
    {
        private float _value;
        private float _weight;

        public float Value
        {
            get => _value;
            set => _value = value.Clamp01();
        }

        public float Weight
        {
            get => _weight;
            set => _weight = value.Clamp01();
        }

        public float Combined => Value * Weight;

        public bool IsZero => MathC.AeqZero(Combined);

        public bool IsOne => MathC.AeqB(Combined, 1.0f);

        public bool Equals(Utility other)
        {
            return MathC.AeqB(Value, other.Value) && MathC.AeqB(Weight, other.Weight);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var util = (Utility)obj;
            return Equals(util);
        }

        public override int GetHashCode()
        {
            return Combined.GetHashCode();
        }

        public int CompareTo(Utility other)
        {
            return Combined.CompareTo(other.Combined);
        }

        public static implicit operator Utility(float a)
        {
            return new Utility(a);
        }

        public static bool operator ==(Utility a, Utility b)
        {
            return MathC.AeqB(a.Value, b.Value) && MathC.AeqB(a.Weight, b.Weight);
        }

        public static bool operator !=(Utility a, Utility b)
        {
            return MathC.AneqB(a.Value, b.Value) || MathC.AneqB(a.Weight, b.Weight);
        }

        public static bool operator >(Utility a, Utility b)
        {
            return a.Combined > b.Combined;
        }

        public static bool operator <(Utility a, Utility b)
        {
            return a.Combined < b.Combined;
        }

        public static bool operator >=(Utility a, Utility b)
        {
            return a.Combined >= b.Combined;
        }

        public static bool operator <=(Utility a, Utility b)
        {
            return a.Combined <= b.Combined;
        }

        public override string ToString()
        {
            return $"[Utility: Value={Value}, Weight={Weight}, Combined={Combined}]";
        }

        public Utility(float value)
        {
            _value = value.Clamp01();
            _weight = 1.0f;
        }

        public Utility(float value, float weight)
        {
            _value = value.Clamp01();
            _weight = weight.Clamp01();
        }
    }

    /// <summary>
    ///     Pointf
    /// </summary>
    public readonly struct Pointf : IEquatable<Pointf>
    {
        public float X { get; }
        public float Y { get; }

        public bool Equals(Pointf other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        public Pointf(float x, float y) : this()
        {
            X = x;
            Y = y;
        }
    }

    #endregion

    #region Extend

    public struct FloatSpring
    {
        public static readonly int Stride = 2 * sizeof(float);
        public float Value;
        public float Velocity;

        public void Reset()
        {
            Value = 0.0f;
            Velocity = 0.0f;
        }

        public void Reset(float initValue)
        {
            Value = initValue;
            Velocity = 0.0f;
        }

        public void Reset(float initValue, float initVelocity)
        {
            Value = initValue;
            Velocity = initVelocity;
        }

        public float TrackDampingRatio(float targetValue, float angularFrequency, float dampingRatio, float deltaTime)
        {
            if (angularFrequency < MathG.Epsilon)
            {
                Velocity = 0.0f;
                return Value;
            }

            var delta = targetValue - Value;
            var f = 1.0f + 2.0f * deltaTime * dampingRatio * angularFrequency;
            var oo = angularFrequency * angularFrequency;
            var hoo = deltaTime * oo;
            var hhoo = deltaTime * hoo;
            var detInv = 1.0f / (f + hhoo);
            var detX = f * Value + deltaTime * Velocity + hhoo * targetValue;
            var detV = Velocity + hoo * delta;
            Velocity = detV * detInv;
            Value = detX * detInv;
            if (!(MathV.Abs(Velocity) < MathG.Epsilon) || !(MathV.Abs(delta) < MathG.Epsilon)) return Value;
            Velocity = 0.0f;
            Value = targetValue;
            return Value;
        }

        public float TrackHalfLife(float targetValue, float frequencyHz, float halfLife, float deltaTime)
        {
            if (halfLife < MathG.Epsilon)
            {
                Velocity = 0.0f;
                Value = targetValue;
                return Value;
            }

            var angularFrequency = frequencyHz * MathG.TwoPi;
            var dampingRatio = 0.6931472f / (angularFrequency * halfLife);
            return TrackDampingRatio(targetValue, angularFrequency, dampingRatio, deltaTime);
        }

        public float TrackExponential(float targetValue, float halfLife, float deltaTime)
        {
            if (halfLife < MathG.Epsilon)
            {
                Velocity = 0.0f;
                Value = targetValue;
                return Value;
            }

            var angularFrequency = 0.6931472f / halfLife;
            const float dampingRatio = 1.0f;
            return TrackDampingRatio(targetValue, angularFrequency, dampingRatio, deltaTime);
        }
    }

    #endregion

    #endregion

    #region Class & Interface

    #region Interval

    public enum IntervalType
    {
        Open,
        Closed
    }

    public readonly struct Interval<T> where T : struct, IComparable<T>
    {
        public T LowerBound { get; }
        public T UpperBound { get; }
        public IntervalType LowerBoundType { get; }
        public IntervalType UpperBoundType { get; }

        public bool Contains(T point)
        {
            var lower = LowerBoundType == IntervalType.Open
                ? LowerBound.CompareTo(point) < 0
                : LowerBound.CompareTo(point) <= 0;
            var upper = UpperBoundType == IntervalType.Open
                ? UpperBound.CompareTo(point) > 0
                : UpperBound.CompareTo(point) >= 0;

            return lower && upper;
        }

        public override string ToString()
        {
            return
                $"{(LowerBoundType == IntervalType.Open ? "(" : "[")}{LowerBound}, {UpperBound}{(UpperBoundType == IntervalType.Open ? ")" : "]")}";
        }

        public Interval(T point) : this(point, point)
        {
        }

        public Interval(T lowerbound, T upperbound,
            IntervalType lowerboundIntervalType = IntervalType.Closed,
            IntervalType upperboundIntervalType = IntervalType.Closed)
            : this()
        {
            var a = lowerbound;
            var b = upperbound;
            var comparison = a.CompareTo(b);

            if (comparison > 0)
            {
                a = upperbound;
                b = lowerbound;
            }

            LowerBound = a;
            UpperBound = b;
            LowerBoundType = lowerboundIntervalType;
            UpperBoundType = upperboundIntervalType;
        }
    }

    public static class Interval
    {
        public static Interval<int> Create(int point)
        {
            return new Interval<int>(point);
        }

        public static Interval<int> Create(int lowerbound, int upperbound,
            IntervalType lowerboundIntervalType = IntervalType.Closed,
            IntervalType upperboundIntervalType = IntervalType.Closed)
        {
            return new Interval<int>(lowerbound, upperbound, lowerboundIntervalType, upperboundIntervalType);
        }

        public static Interval<float> Create(float point)
        {
            return new Interval<float>(point);
        }

        public static Interval<float> Create(float lowerbound, float upperbound,
            IntervalType lowerboundIntervalType = IntervalType.Closed,
            IntervalType upperboundIntervalType = IntervalType.Closed)
        {
            return new Interval<float>(lowerbound, upperbound, lowerboundIntervalType, upperboundIntervalType);
        }

        public static Interval<double> Create(double lowerbound, double upperbound,
            IntervalType lowerboundIntervalType = IntervalType.Closed,
            IntervalType upperboundIntervalType = IntervalType.Closed)
        {
            return new Interval<double>(lowerbound, upperbound, lowerboundIntervalType, upperboundIntervalType);
        }
    }

    public static class IntervalExtensions
    {
        public static readonly IntervalType Open = IntervalType.Open;
        public static readonly IntervalType Closed = IntervalType.Closed;

        public static bool Overlaps(this Interval<float> @this, Interval<float> other)
        {
            return @this.Contains(other.LowerBound) || @this.Contains(other.UpperBound);
        }

        public static bool Adjacent(this Interval<float> @this, Interval<float> other)
        {
            if (MathC.AeqB(@this.UpperBound, other.LowerBound) &&
                @this.UpperBoundType == Closed &&
                other.LowerBoundType == Closed)
                return true;
            return MathC.AeqB(@this.LowerBound, other.UpperBound) &&
                   @this.LowerBoundType == Closed &&
                   other.UpperBoundType == Closed;
        }

        public static bool LeftAdjacent(this Interval<float> @this, Interval<float> other)
        {
            return MathC.AeqB(@this.UpperBound, other.LowerBound) &&
                   @this.UpperBoundType == Closed &&
                   other.LowerBoundType == Closed;
        }

        public static bool RightAdjacent(this Interval<float> @this, Interval<float> other)
        {
            return MathC.AeqB(@this.LowerBound, other.UpperBound) &&
                   @this.LowerBoundType == Closed &&
                   other.UpperBoundType == Closed;
        }

        public static bool LessThan(this Interval<float> @this, Interval<float> other)
        {
            return @this.UpperBound <= other.LowerBound;
        }

        public static bool GreaterThan(this Interval<float> @this, Interval<float> other)
        {
            return @this.LowerBound >= other.UpperBound;
        }

        public static int CompareTo(this Interval<float> @this, Interval<float> other)
        {
            if (@this.LessThan(other))
                return -1;
            return @this.GreaterThan(other) ? 1 : 0;
        }

        public static int Length(this Interval<int> @this)
        {
            return @this.UpperBound - @this.LowerBound;
        }

        public static float Length(this Interval<float> @this)
        {
            return @this.UpperBound - @this.LowerBound;
        }

        public static double Length(this Interval<double> @this)
        {
            return @this.UpperBound - @this.LowerBound;
        }

        public static Interval<T> ChangeLowerBound<T>(this Interval<T> @this, T lowerBound)
            where T : struct, IComparable<T>
        {
            return lowerBound.CompareTo(@this.UpperBound) >= 0
                ? new Interval<T>(lowerBound, lowerBound)
                : new Interval<T>(lowerBound, @this.UpperBound, @this.LowerBoundType, @this.UpperBoundType);
        }

        public static Interval<T> ChangeUpperBound<T>(this Interval<T> @this, T upperBound)
            where T : struct, IComparable<T>
        {
            return upperBound.CompareTo(@this.LowerBound) <= 0
                ? new Interval<T>(upperBound, upperBound)
                : new Interval<T>(@this.LowerBound, upperBound, @this.LowerBoundType, @this.UpperBoundType);
        }
    }

    #endregion

    #region Evaluator

    #region Core

    public interface IEvaluator
    {
        Pointf PtA { get; }
        Pointf PtB { get; }
        float MinX { get; }
        float MaxX { get; }
        float MinY { get; }
        float MaxY { get; }
        Interval<float> XInterval { get; }
        Interval<float> YInterval { get; }
        bool IsInverted { get; set; }
        float Evaluate(float x);
    }

    public class EvaluatorBase : IEvaluator, IComparable<IEvaluator>
    {
        public float Xa;
        public float Xb;
        public float Ya;
        public float Yb;

        public EvaluatorBase()
        {
            Initialize(0.0f, 0.0f, 1.0f, 1.0f);
        }

        public EvaluatorBase(Pointf ptA, Pointf ptB)
        {
            Initialize(ptA.X, ptA.Y, ptB.X, ptB.Y);
        }

        public int CompareTo(IEvaluator other)
        {
            return XInterval.CompareTo(other.XInterval);
        }

        public Pointf PtA => new(Xa, Ya);

        public Pointf PtB => new(Xb, Yb);

        public float MinX => Xa;

        public float MaxX => Xb;

        public float MinY => Math.Min(Ya, Yb);

        public float MaxY => Math.Max(Ya, Yb);

        public Interval<float> XInterval => new(MinX, MaxX);

        public Interval<float> YInterval => new(MinY, MaxY);

        public bool IsInverted { get; set; }

        float IEvaluator.Evaluate(float x)
        {
            return IsInverted ? 1f - Evaluate(x) : Evaluate(x);
        }

        public virtual float Evaluate(float x)
        {
            return 0f;
        }

        public void Initialize(float xA, float yA, float xB, float yB)
        {
            if (MathC.AeqB(xA, xB))
                throw new EvaluatorDxZeroException();
            if (xA > xB)
                throw new EvaluatorXaGreaterThanXbException();
            Xa = xA;
            Xb = xB;
            Ya = yA.Clamp01();
            Yb = yB.Clamp01();
        }

        public class EvaluatorDxZeroException : Exception
        {
        }

        public class EvaluatorXaGreaterThanXbException : Exception
        {
        }
    }

    #endregion

    #region Extend

    public class CompositeEvaluator : EvaluatorBase
    {
        public List<IEvaluator> Evaluators;

        public CompositeEvaluator()
        {
            Evaluators = new List<IEvaluator>();
        }

        public override float Evaluate(float x)
        {
            var ev = FindEvaluator(x);
            return ev?.Evaluate(x) ?? LinearHoleInterpolator(x);
        }

        public void Add(IEvaluator ev)
        {
            if (DoesNotOverlapWithAnyEvaluator(ev))
                Evaluators.Add(ev);

            Evaluators.Sort((e1, e2) => e1.XInterval.CompareTo(e2.XInterval));
            UpdateXyPoints();
        }

        public bool DoesNotOverlapWithAnyEvaluator(IEvaluator ev)
        {
            return Evaluators.Where(cev => ev.XInterval.Overlaps(cev.XInterval))
                .All(cev => ev.XInterval.Adjacent(cev.XInterval));
        }

        public void UpdateXyPoints()
        {
            var count = Evaluators.Count;
            if (count == 1)
                SingleEvaluatorXyPointsUpdate();
            else
                MultiEvaluatorXyPointsUpdate();
        }

        public void SingleEvaluatorXyPointsUpdate()
        {
            Xa = Evaluators[0].PtA.X;
            Ya = Evaluators[0].PtA.Y;
            Xb = Evaluators[0].PtB.X;
            Yb = Evaluators[0].PtB.Y;
        }

        public void MultiEvaluatorXyPointsUpdate()
        {
            foreach (var ev in Evaluators)
            {
                if (Xa >= ev.MinX)
                {
                    Xa = ev.MinX;
                    Ya = ev.PtA.Y;
                }

                if (!(Xb <= ev.MaxX)) continue;
                Xb = ev.MaxX;
                Yb = ev.PtB.Y;
            }
        }

        public IEvaluator FindEvaluator(float x)
        {
            var evCount = Evaluators.Count;
            if (x.InInterval(XInterval))
                return FindInternalEvaluator(x);

            if (x.AboveInterval(XInterval))
                return Evaluators[evCount - 1];

            return x.BelowInterval(XInterval) ? Evaluators[0] : null;
        }

        public IEvaluator FindInternalEvaluator(float x)
        {
            var evCount = Evaluators.Count;
            for (var i = 0; i < evCount; i++)
                if (x.InInterval(Evaluators[i].XInterval))
                    return Evaluators[i];
            return null;
        }

        public float LinearHoleInterpolator(float x)
        {
            var lrev = FindLeftAndRightInterpolators(x);
            var xl = lrev.Key.MaxX;
            var yl = lrev.Key.Evaluate(xl);
            var xr = lrev.Value.MinX;
            var yr = lrev.Value.Evaluate(xr);
            var alpha = (x - xl) / (xr - xl);
            return yl + alpha * (yr - yl);
        }

        public KeyValuePair<IEvaluator, IEvaluator> FindLeftAndRightInterpolators(float x)
        {
            var evCount = Evaluators.Count;
            IEvaluator lev = null;
            IEvaluator rev = null;
            for (var i = 0; i < evCount - 1; i++)
            {
                lev = Evaluators[i];
                rev = Evaluators[i + 1];
                if (x.AboveInterval(lev.XInterval) &&
                    x.BelowInterval(rev.XInterval))
                    break;
            }

            return new KeyValuePair<IEvaluator, IEvaluator>(lev, rev);
        }
    }

    public class LinearEvaluator : EvaluatorBase
    {
        private float _dyOverDx;

        public LinearEvaluator()
        {
            Initialize();
        }

        public LinearEvaluator(Pointf ptA, Pointf ptB) : base(ptA, ptB)
        {
            Initialize();
        }

        public override float Evaluate(float x)
        {
            return (Ya + _dyOverDx * (x - Xa)).Clamp01();
        }

        private void Initialize()
        {
            _dyOverDx = (Yb - Ya) / (Xb - Xa);
        }
    }

    public class PowerEvaluator : EvaluatorBase
    {
        private const float MinP = 0.0f;
        private const float MaxP = 10000f;
        private readonly float _p;
        private float _dy;

        public PowerEvaluator()
        {
            _p = 2.0f;
            Initialize();
        }

        public PowerEvaluator(Pointf ptA, Pointf ptB) : base(ptA, ptB)
        {
            _p = 2.0f;
            Initialize();
        }

        public PowerEvaluator(Pointf ptA, Pointf ptB, float power) : base(ptA, ptB)
        {
            _p = MathV.Clamp(power, MinP, MaxP);
            Initialize();
        }

        public override float Evaluate(float x)
        {
            var cx = MathV.Clamp(x, Xa, Xb);
            cx = _dy * (float)Math.Pow((cx - Xa) / (Xb - Xa), _p) + Ya;
            return cx;
        }

        private void Initialize()
        {
            _dy = Yb - Ya;
        }
    }

    public class SigmoidEvaluator : EvaluatorBase
    {
        private const float MinK = -0.99999f;
        private const float MaxK = 0.99999f;
        private readonly float _k;
        private float _dyOverTwo;
        private float _oneMinusK;
        private float _twoOverDx;
        private float _xMean;
        private float _yMean;

        public SigmoidEvaluator()
        {
            _k = -0.6f;
            Initialize();
        }

        public SigmoidEvaluator(Pointf ptA, Pointf ptB) : base(ptA, ptB)
        {
            _k = -0.6f;
            Initialize();
        }

        public SigmoidEvaluator(Pointf ptA, Pointf ptB, float k) : base(ptA, ptB)
        {
            _k = MathV.Clamp(k, MinK, MaxK);
            Initialize();
        }

        public override float Evaluate(float x)
        {
            var cxMinusXMean = MathV.Clamp(x, Xa, Xb) - _xMean;
            var num = _twoOverDx * cxMinusXMean * _oneMinusK;
            var den = _k * (1 - 2 * Math.Abs(_twoOverDx * cxMinusXMean)) + 1;
            var val = _dyOverTwo * (num / den) + _yMean;
            return val;
        }

        private void Initialize()
        {
            _twoOverDx = Math.Abs(2.0f / (Xb - Xa));
            _xMean = (Xa + Xb) / 2.0f;
            _yMean = (Ya + Yb) / 2.0f;
            _dyOverTwo = (Yb - Ya) / 2.0f;
            _oneMinusK = 1.0f - _k;
        }
    }

    #endregion

    #endregion

    #region Queue

    public interface IPriorityQueueHandle
    {
    }

    public interface IHeapItem
    {
        IPriorityQueueHandle Handle { get; set; }
    }

    public interface IPriorityQueue<TQueuedItem>
    {
        bool HasNext { get; }
        int Count { get; }
        TQueuedItem Peek();
        void Enqueue(TQueuedItem item);
        TQueuedItem Dequeue();
        bool Contains(TQueuedItem item);
        void Remove(TQueuedItem item);
        void UpdatePriority(TQueuedItem item);
        void Clear();
    }

    public class PriorityQueue<TQueuedItem> : IPriorityQueue<TQueuedItem>
        where TQueuedItem : class, IHeapItem
    {
        private const int DefaultSize = 128;
        private readonly IComparer<TQueuedItem> _comparer;
        private HeapNode[] _heap;
        private ulong _runningCount;

        public PriorityQueue(IComparer<TQueuedItem> comparer = null)
        {
            _heap = new HeapNode[DefaultSize];
            _comparer = comparer ?? Comparer<TQueuedItem>.Default;
            Count = 0;
        }

        public PriorityQueue(int initialHeapSize, IComparer<TQueuedItem> comparer = null)
        {
            _heap = initialHeapSize < 1 ? new HeapNode[DefaultSize] : new HeapNode[initialHeapSize];
            _comparer = comparer ?? Comparer<TQueuedItem>.Default;
            Count = 0;
        }

        public bool HasNext => Count > 0;

        public int Count { get; private set; }

        public TQueuedItem Peek()
        {
            return _heap[1]?.Item;
        }

        public void Enqueue(TQueuedItem item)
        {
            var node = new HeapNode(item);
            if (Count + 1 >= _heap.Length)
                ResizeHeap();
            Count++;
            _heap[Count] = node;
            node.Handle.Index = Count;
            node.Handle.Order = _runningCount++;
            MinBubbleUp(Count);
        }

        public TQueuedItem Dequeue()
        {
            if (Count < 1)
                return default;
            var ret = _heap[1].Item;
            _heap[1] = _heap[Count];
            _heap[Count] = null;
            Count--;
            MinHeapify(1);
            return ret;
        }

        public bool Contains(TQueuedItem item)
        {
            if (item.Handle is not Handle h || h.Index > Count)
                return false;
            return _heap[h.Index].Item == item;
        }

        public void Remove(TQueuedItem item)
        {
            if (item?.Handle is not Handle itemHandle)
                return;
            var itemIndex = itemHandle.Index;
            if (itemIndex == Count)
            {
                _heap[Count] = null;
                Count--;
                return;
            }

            Swap(itemIndex, Count);
            _heap[Count] = null;
            Count--;
            var parent = itemIndex >> 1;
            if (parent > 0 && _comparer.Compare(_heap[itemIndex].Item, _heap[parent].Item) < 0)
                MinBubbleUp(itemIndex);
            else
                MinHeapify(itemIndex);
        }

        public void UpdatePriority(TQueuedItem item)
        {
            if (item.Handle is not Handle h)
                return;
            var idx = h.Index;
            h.Order = _runningCount++;
            var parent = idx >> 1;
            if (parent > 0 && _comparer.Compare(_heap[idx].Item, _heap[parent].Item) < 0)
                MinBubbleUp(idx);
            else
                MinHeapify(idx);
        }

        public void Clear()
        {
            Array.Clear(_heap, 1, Count);
            Count = 0;
        }

        public bool IsHeapValid()
        {
            for (var i = 1; i < _heap.Length; i++)
                if (_heap[i] != null)
                {
                    var left = i << 1;
                    if (left < _heap.Length &&
                        _heap[left] != null &&
                        _comparer.Compare(_heap[left].Item, _heap[i].Item) < 0)
                        return false;
                    var right = left | 1;
                    if (right < _heap.Length &&
                        _heap[right] != null &&
                        _comparer.Compare(_heap[right].Item, _heap[i].Item) < 0)
                        return false;
                }

            return true;
        }

        private void ResizeHeap()
        {
            var resizedHeap = new HeapNode[2 * _heap.Length];
            Array.Copy(_heap, 1, resizedHeap, 1, Count);
            _heap = resizedHeap;
        }

        private void MinHeapify(int i)
        {
            while (true)
            {
                var smallest = i;
                var left = i << 1;
                var right = (i << 1) | 1;
                if (left <= Count)
                {
                    var cmp = _comparer.Compare(_heap[left].Item, _heap[i].Item);
                    if (cmp < 0 || (cmp == 0 && _heap[left].Handle.Order < _heap[i].Handle.Order))
                        smallest = left;
                }

                if (right <= Count)
                {
                    var cmp = _comparer.Compare(_heap[right].Item, _heap[smallest].Item);
                    if (cmp < 0 || (cmp == 0 && _heap[right].Handle.Order < _heap[smallest].Handle.Order))
                        smallest = right;
                }

                if (smallest == i)
                    return;
                Swap(i, smallest);
                i = smallest;
            }
        }

        private void MinBubbleUp(int i)
        {
            if (i < 1)
                return;
            var parent = i >> 1;
            while (parent > 0)
                if (_comparer.Compare(_heap[i].Item, _heap[parent].Item) < 0)
                {
                    Swap(parent, i);
                    i = parent;
                    parent >>= 1;
                }
                else
                {
                    break;
                }
        }

        private void Swap(int i, int j)
        {
            (_heap[i], _heap[j]) = (_heap[j], _heap[i]);
            _heap[i].Handle.Index = i;
            _heap[j].Handle.Index = j;
        }

        private class Handle : IPriorityQueueHandle
        {
            internal int Index = -1;
            internal ulong Order;
        }

        private class HeapNode
        {
            internal readonly Handle Handle;
            internal readonly TQueuedItem Item;

            public HeapNode(TQueuedItem item)
            {
                Item = item;
                Handle = new Handle();
                Item.Handle = Handle;
            }

            ~HeapNode()
            {
                Item.Handle = null;
            }
        }
    }

    #endregion

    #region Cache

    /// <summary>
    ///     缓冲区
    /// </summary>
    public interface ICircularBuffer<T>
    {
        int Count { get; }
        int Capacity { get; set; }
        T Head { get; }
        T Tail { get; }
        T this[int index] { get; set; }
        T Enqueue(T item);
        T Dequeue();
        void Clear();
        int IndexOf(T item);
        void RemoveAt(int index);
    }

    /// <summary>
    ///     缓冲区
    /// </summary>
    public class CircularBuffer<T> : ICircularBuffer<T>, IEnumerable<T>
    {
        public const int DefaultSize = 4;
        public T[] Buffer;
        public int MHead;
        public int MTail;

        public CircularBuffer()
        {
            Initialize(DefaultSize);
        }

        public CircularBuffer(int size)
        {
            Initialize(size);
        }

        /// <summary>
        ///     元素数
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        ///     最大容量.
        /// </summary>
        public int Capacity
        {
            get => Buffer.Length;
            set
            {
                if (value < 0)
                    return;
                if (value == Buffer.Length)
                    return;
                var buffer = new T[value];
                var count = 0;
                while (Count > 0 && count < value)
                    buffer[count++] = Dequeue();
                Buffer = buffer;
                Count = count;
                MHead = count - 1;
                MTail = 0;
            }
        }

        /// <summary>
        ///     获取头部
        /// </summary>
        public T Head => Buffer[MHead];

        /// <summary>
        ///     获取尾部
        /// </summary>
        public T Tail => Buffer[MTail];

        /// <summary>
        ///     进入队列
        /// </summary>
        /// <param name="item">Item.</param>
        public T Enqueue(T item)
        {
            MHead = (MHead + 1) % Capacity;
            var overwritten = Buffer[MHead];
            Buffer[MHead] = item;
            if (Count == Capacity)
                MTail = (MTail + 1) % Capacity;
            else
                ++Count;
            return overwritten;
        }

        /// <summary>
        ///     退出队列
        /// </summary>
        public T Dequeue()
        {
            if (Count == 0)
                return default;
            var dequeued = Buffer[MTail];
            Buffer[MTail] = default;
            MTail = (MTail + 1) % Capacity;
            --Count;
            return dequeued;
        }

        /// <summary>
        ///     清空
        /// </summary>
        public void Clear()
        {
            MHead = Capacity - 1;
            MTail = 0;
            Count = 0;
        }

        /// <summary>
        ///     获取Id
        /// </summary>
        public int IndexOf(T item)
        {
            for (var i = 0; i < Count; i++)
                if (Equals(item, this[i]))
                    return i;

            return -1;
        }

        /// <summary>
        ///     移除指定下标的元素
        /// </summary>
        public void RemoveAt(int index)
        {
            if (index < 0 ||
                index >= Count)
                throw new ArgumentOutOfRangeException(nameof(index));
            for (var i = index; i > 0; i--)
                this[i] = this[i - 1];

            Dequeue();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 ||
                    index >= Count)
                    throw new ArgumentOutOfRangeException(index.ToString());

                return Buffer[(MTail + index) % Capacity];
            }
            set
            {
                if (index < 0 ||
                    index >= Count)
                    throw new ArgumentOutOfRangeException(index.ToString());

                Buffer[(MTail + index) % Capacity] = value;
            }
        }

        /// <summary>
        ///     获取Enumerator
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            if (Count == 0 ||
                Capacity == 0)
                yield break;

            for (var i = 0; i < Count; i++)
                yield return this[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Initialize(int size)
        {
            if (size < 0)
                size = DefaultSize;
            Buffer = new T[size];
            MHead = size - 1;
        }
    }

    /// <summary>
    ///     移动平均值
    /// </summary>
    public class MovingAverage
    {
        private const int DefaultSize = 4;
        private CircularBuffer<float> _buffer;
        private bool _latch = true;
        private float _oneOverN = 1.0f;

        public MovingAverage()
        {
            Initialize(DefaultSize);
        }

        public MovingAverage(int length)
        {
            Initialize(length);
        }

        public float Mean { get; private set; }

        public int MovingAverageDepth => _buffer.Capacity;

        public void Enqueue(float val)
        {
            _buffer.Enqueue(val);
            UpdateTheMean();
        }

        private void Initialize(int size)
        {
            if (size < 2)
            {
                _buffer = new CircularBuffer<float>(DefaultSize);
                _oneOverN = 1.0f / DefaultSize;
            }
            else
            {
                _buffer = new CircularBuffer<float>(size);
                _oneOverN = 1.0f / size;
            }
        }

        public float UpdateTheMean()
        {
            if (_latch)
            {
                Mean = _buffer.Mean();
                if (_buffer.Count == _buffer.Capacity)
                    _latch = false;
                return Mean;
            }

            Mean += _oneOverN * (_buffer.Head - _buffer.Tail);
            return Mean;
        }
    }

    #endregion

    #region Extension & Fuction

    #region Core

    public class FutureWithPredicate<T>
    {
        public T Value { get; set; }
        public Func<T, bool> Predicate { get; set; }
        public bool Matched => Predicate(Value);
    }

    public static class PatternMatchingExtensions
    {
        public static Tuple<FutureWithPredicate<T>, bool> When<T>(this T value, Func<T, bool> predicate)
        {
            return new Tuple<FutureWithPredicate<T>, bool>(
                new FutureWithPredicate<T> { Value = value, Predicate = predicate }, false);
        }

        public static Tuple<T, bool> Do<T>(this Tuple<FutureWithPredicate<T>, bool> future, Action<T> lambda)
        {
            if (future.Item1.Matched)
                lambda(future.Item1.Value);

            return new Tuple<T, bool>(future.Item1.Value, future.Item1.Matched | future.Item2);
        }

        public static Tuple<FutureWithPredicate<T>, bool> When<T>(this Tuple<T, bool> value, Func<T, bool> predicate)
        {
            return new Tuple<FutureWithPredicate<T>, bool>(
                new FutureWithPredicate<T> { Value = value.Item1, Predicate = predicate }, value.Item2);
        }

        public static Tuple<T, object> Otherwise<T>(this Tuple<T, bool> result, Action<T> lambda)
        {
            if (!result.Item2)
                lambda(result.Item1);

            return new Tuple<T, object>(result.Item1, new object());
        }

        public static Tuple<T, bool> Then<T>(this Tuple<T, bool> previous, Action<T> lambda)
        {
            if (previous.Item2 && lambda != null)
                lambda(previous.Item1);

            return previous;
        }

        public static Tuple<T, bool> Then<T>(this Tuple<T, bool> previous, Action lambda)
        {
            if (previous.Item2 && lambda != null)
                lambda();

            return previous;
        }
    }

    public static class QueryHelpers
    {
        public static QueryBuilder GenerateQuery(this ValueTuple<int, int> intialElementTuple,
            InitialOperation initialOperation)
        {
            return new QueryBuilder(intialElementTuple.Item1, intialElementTuple.Item2, initialOperation);
        }

        public static QueryBuilder GenerateQuery(this Tuple<int, int> intialElementTuple,
            InitialOperation initialOperation)
        {
            return new QueryBuilder(intialElementTuple.Item1, intialElementTuple.Item2, initialOperation);
        }
    }

    public struct QueryBuilder : ICloneable
    {
        public readonly int BaseElementX;
        public readonly int BaseElementY;
        public readonly InitialOperation Operation;
        public int CurrentValue;
        public int OperationsDone { get; private set; }

        public QueryBuilder(int x, int y, InitialOperation initialOperation)
        {
            BaseElementX = x;
            BaseElementY = y;
            CurrentValue = 0;
            OperationsDone = 0;
            Operation = initialOperation;

            CurrentValue = SetInitialValue(x, y, initialOperation);
        }

        private int SetInitialValue(int x, int y, InitialOperation initialOperation)
        {
            try
            {
                return initialOperation switch
                {
                    InitialOperation.Addition => x.AddWith(y),
                    InitialOperation.Subtraction => y.SubtractFrom(x),
                    InitialOperation.Multiplication => x.MultiplyWith(y),
                    InitialOperation.Division => x.DivideBy(y),
                    InitialOperation.Modulus => x.ModulusBy(y),
                    _ => throw new ArgumentOutOfRangeException(nameof(initialOperation), initialOperation, null)
                };
            }
            finally
            {
                OperationsDone++;
            }
        }

        public object Clone()
        {
            return new QueryBuilder(BaseElementX, BaseElementY, Operation);
        }

        public int Build()
        {
            return CurrentValue;
        }

        public QueryBuilder Sum()
        {
            CurrentValue = BaseElementX + BaseElementY;
            OperationsDone++;
            return this;
        }

        public QueryBuilder Product()
        {
            CurrentValue = BaseElementX * BaseElementY;
            OperationsDone++;
            return this;
        }

        public QueryBuilder RaiseTo(int power)
        {
            CurrentValue = (int)Math.Pow(CurrentValue, power);
            OperationsDone++;
            return this;
        }

        public QueryBuilder Difference()
        {
            CurrentValue = BaseElementX - BaseElementY;
            OperationsDone++;
            return this;
        }

        public QueryBuilder Subtract(int x)
        {
            CurrentValue -= x;
            OperationsDone++;
            return this;
        }

        public QueryBuilder Add(int x)
        {
            CurrentValue += x;
            OperationsDone++;
            return this;
        }

        public QueryBuilder Multiply(int x)
        {
            CurrentValue *= x;
            OperationsDone++;
            return this;
        }

        public QueryBuilder Divide(int x)
        {
            CurrentValue /= x;
            OperationsDone++;
            return this;
        }

        public QueryBuilder Mod(int x)
        {
            CurrentValue %= x;
            OperationsDone++;
            return this;
        }

        public enum InitialOperation
        {
            Addition,
            Subtraction,
            Multiplication,
            Division,
            Modulus
        }
    }

    public static class ValueTupleOperations
    {
        public static int Sum(this ValueTuple<int, int> tuple)
        {
            return tuple.Item1 + tuple.Item2;
        }

        public static int Difference(this ValueTuple<int, int> tuple)
        {
            return tuple.Item1 - tuple.Item2;
        }

        public static int Product(this ValueTuple<int, int> tuple)
        {
            return tuple.Item1 * tuple.Item2;
        }

        public static int Quotient(this ValueTuple<int, int> tuple)
        {
            return tuple.Item1 / tuple.Item2;
        }

        public static int ModRemainder(this ValueTuple<int, int> tuple)
        {
            return tuple.Item1 % tuple.Item2;
        }

        public static int Sum(this ValueTuple<int, int, int> tuple)
        {
            return tuple.Item1 + tuple.Item2 + tuple.Item3;
        }

        public static int Difference(this ValueTuple<int, int, int> tuple)
        {
            return tuple.Item1 - tuple.Item2 - tuple.Item3;
        }

        public static int Product(this ValueTuple<int, int, int> tuple)
        {
            return tuple.Item1 * tuple.Item2 * tuple.Item3;
        }

        public static int Quotient(this ValueTuple<int, int, int> tuple)
        {
            return tuple.Item1 / tuple.Item2 / tuple.Item3;
        }

        public static int ModRemainder(this ValueTuple<int, int, int> tuple)
        {
            return tuple.Item1 % tuple.Item2 % tuple.Item3;
        }

        public static int Sum(this ValueTuple<int, int, int, int> tuple)
        {
            return tuple.Item1 + tuple.Item2 + tuple.Item3 + tuple.Item4;
        }

        public static int Difference(this ValueTuple<int, int, int, int> tuple)
        {
            return tuple.Item1 - tuple.Item2 - (tuple.Item3 - tuple.Item4);
        }

        public static int Product(this ValueTuple<int, int, int, int> tuple)
        {
            return tuple.Item1 * tuple.Item2 * tuple.Item3 * tuple.Item4;
        }

        public static int Quotient(this ValueTuple<int, int, int, int> tuple)
        {
            return tuple.Item1 / tuple.Item2 / (tuple.Item3 / tuple.Item4);
        }

        public static int ModRemainder(this ValueTuple<int, int, int, int> tuple)
        {
            return tuple.Item1 % tuple.Item2 % (tuple.Item3 % tuple.Item4);
        }
    }

    public static class Internals
    {
        public static Random Random => MathV.RandomV;
    }

    public static class DoubleOperations
    {
        public static double AddWith(this double x, double y)
        {
            return x + y;
        }

        public static double SubtractFrom(this double x, double y)
        {
            return y - x;
        }

        public static double DivideBy(this double x, double y)
        {
            return x / y;
        }

        public static double ModulusBy(this double x, double y)
        {
            return x % y;
        }

        public static double MultiplyWith(this double x, double y)
        {
            return x * y;
        }

        public static double SquareRoot(this double x)
        {
            return Math.Sqrt(x);
        }

        public static double Round(this double x, int decimalPos = 0,
            MidpointRounding midpointRounding = MidpointRounding.AwayFromZero)
        {
            return Math.Round(x, decimalPos, midpointRounding);
        }

        public static double PowerOf(this double x, double raiseTo)
        {
            return Math.Pow(x, raiseTo);
        }

        public static double Absolute(this double x)
        {
            return Math.Abs(x);
        }

        public static TimeSpan AsHoursSpan(this double x)
        {
            return TimeSpan.FromHours(x);
        }

        public static TimeSpan AsDaysSpan(this double x)
        {
            return TimeSpan.FromDays(x);
        }

        public static TimeSpan AsMinutesSpan(this double x)
        {
            return TimeSpan.FromMinutes(x);
        }
    }

    public static class IntegerOperations
    {
        public static int AddWith(this int x, int y)
        {
            return x + y;
        }

        public static int SubtractFrom(this int x, int y)
        {
            return y - x;
        }

        public static int DivideBy(this int x, int y)
        {
            return x / y;
        }

        public static int ModulusBy(this int x, int y)
        {
            return x % y;
        }

        public static int MultiplyWith(this int x, int y)
        {
            return x * y;
        }

        public static int Absolute(this int x)
        {
            return Math.Abs(x);
        }

        public static int AsRandomMaxNext(this int x)
        {
            return Internals.Random.Next(x);
        }

        public static bool IsWithin(this int x, int y, int z)
        {
            return x >= y && x <= z;
        }

        public static bool IsIntegerMax(this int x)
        {
            return x == int.MaxValue;
        }

        public static bool IsIntegerMin(this int x)
        {
            return x == int.MinValue;
        }

        public static bool AsBool(this int x)
        {
            return x >= 1;
        }
    }

    public static class MathH
    {
        public const int GammaN = 10;

        public const double GammaR = 10.900511;

        public static readonly double[] BesselI0A =
        {
            -4.41534164647933937950e-18, 3.33079451882223809783e-17, -2.43127984654795469359e-16,
            1.71539128555513303061e-15, -1.16853328779934516808e-14, 7.67618549860493561688e-14,
            -4.85644678311192946090e-13, 2.95505266312963983461e-12, -1.72682629144155570723e-11,
            9.67580903537323691224e-11, -5.18979560163526290666e-10, 2.65982372468238665035e-9,
            -1.30002500998624804212e-8, 6.04699502254191894932e-8, -2.67079385394061173391e-7,
            1.11738753912010371815e-6, -4.41673835845875056359e-6, 1.64484480707288970893e-5,
            -5.75419501008210370398e-5, 1.88502885095841655729e-4, -5.76375574538582365885e-4,
            1.63947561694133579842e-3, -4.32430999505057594430e-3, 1.05464603945949983183e-2,
            -2.37374148058994688156e-2, 4.93052842396707084878e-2, -9.49010970480476444210e-2,
            1.71620901522208775349e-1, -3.04682672343198398683e-1, 6.76795274409476084995e-1
        };

        public static readonly double[] BesselI0B =
        {
            -7.23318048787475395456e-18, -4.83050448594418207126e-18, 4.46562142029675999901e-17,
            3.46122286769746109310e-17, -2.82762398051658348494e-16, -3.42548561967721913462e-16,
            1.77256013305652638360e-15, 3.81168066935262242075e-15, -9.55484669882830764870e-15,
            -4.15056934728722208663e-14, 1.54008621752140982691e-14, 3.85277838274214270114e-13,
            7.18012445138366623367e-13, -1.79417853150680611778e-12, -1.32158118404477131188e-11,
            -3.14991652796324136454e-11, 1.18891471078464383424e-11, 4.94060238822496958910e-10,
            3.39623202570838634515e-9, 2.26666899049817806459e-8, 2.04891858946906374183e-7, 2.89137052083475648297e-6,
            6.88975834691682398426e-5, 3.36911647825569408990e-3, 8.04490411014108831608e-1
        };

        public static readonly double[] BesselI1A =
        {
            2.77791411276104639959e-18, -2.11142121435816608115e-17, 1.55363195773620046921e-16,
            -1.10559694773538630805e-15, 7.60068429473540693410e-15, -5.04218550472791168711e-14,
            3.22379336594557470981e-13, -1.98397439776494371520e-12, 1.17361862988909016308e-11,
            -6.66348972350202774223e-11, 3.62559028155211703701e-10, -1.88724975172282928790e-9,
            9.38153738649577178388e-9, -4.44505912879632808065e-8, 2.00329475355213526229e-7,
            -8.56872026469545474066e-7, 3.47025130813767847674e-6, -1.32731636560394358279e-5,
            4.78156510755005422638e-5, -1.61760815825896745588e-4, 5.12285956168575772895e-4,
            -1.51357245063125314899e-3, 4.15642294431288815669e-3, -1.05640848946261981558e-2,
            2.47264490306265168283e-2, -5.29459812080949914269e-2, 1.02643658689847095384e-1,
            -1.76416518357834055153e-1, 2.52587186443633654823e-1
        };

        public static readonly double[] BesselI1B =
        {
            7.51729631084210481353e-18, 4.41434832307170791151e-18, -4.65030536848935832153e-17,
            -3.20952592199342395980e-17, 2.96262899764595013876e-16, 3.30820231092092828324e-16,
            -1.88035477551078244854e-15, -3.81440307243700780478e-15, 1.04202769841288027642e-14,
            4.27244001671195135429e-14, -2.10154184277266431302e-14, -4.08355111109219731823e-13,
            -7.19855177624590851209e-13, 2.03562854414708950722e-12, 1.41258074366137813316e-11,
            3.25260358301548823856e-11, -1.89749581235054123450e-11, -5.58974346219658380687e-10,
            -3.83538038596423702205e-9, -2.63146884688951950684e-8, -2.51223623787020892529e-7,
            -3.88256480887769039346e-6, -1.10588938762623716291e-4, -9.76109749136146840777e-3,
            7.78576235018280120474e-1
        };

        public static readonly double[] BesselK0A =
        {
            1.37446543561352307156e-16, 4.25981614279661018399e-14, 1.03496952576338420167e-11,
            1.90451637722020886025e-9, 2.53479107902614945675e-7, 2.28621210311945178607e-5, 1.26461541144692592338e-3,
            3.59799365153615016266e-2, 3.44289899924628486886e-1, -5.35327393233902768720e-1
        };

        public static readonly double[] BesselK0B =
        {
            5.30043377268626276149e-18, -1.64758043015242134646e-17, 5.21039150503902756861e-17,
            -1.67823109680541210385e-16, 5.51205597852431940784e-16, -1.84859337734377901440e-15,
            6.34007647740507060557e-15, -2.22751332699166985548e-14, 8.03289077536357521100e-14,
            -2.98009692317273043925e-13, 1.14034058820847496303e-12, -4.51459788337394416547e-12,
            1.85594911495471785253e-11, -7.95748924447710747776e-11, 3.57739728140030116597e-10,
            -1.69753450938905987466e-9, 8.57403401741422608519e-9, -4.66048989768794782956e-8,
            2.76681363944501510342e-7, -1.83175552271911948767e-6, 1.39498137188764993662e-5,
            -1.28495495816278026384e-4, 1.56988388573005337491e-3, -3.14481013119645005427e-2, 2.44030308206595545468e0
        };

        public static readonly double[] BesselK1A =
        {
            -7.02386347938628759343e-18, -2.42744985051936593393e-15, -6.66690169419932900609e-13,
            -1.41148839263352776110e-10, -2.21338763073472585583e-8, -2.43340614156596823496e-6,
            -1.73028895751305206302e-4, -6.97572385963986435018e-3, -1.22611180822657148235e-1,
            -3.53155960776544875667e-1, 1.52530022733894777053e0
        };

        public static readonly double[] BesselK1B =
        {
            -5.75674448366501715755e-18, 1.79405087314755922667e-17, -5.68946255844285935196e-17,
            1.83809354436663880070e-16, -6.05704724837331885336e-16, 2.03870316562433424052e-15,
            -7.01983709041831346144e-15, 2.47715442448130437068e-14, -8.97670518232499435011e-14,
            3.34841966607842919884e-13, -1.28917396095102890680e-12, 5.13963967348173025100e-12,
            -2.12996783842756842877e-11, 9.21831518760500529508e-11, -4.19035475934189648750e-10,
            2.01504975519703286596e-9, -1.03457624656780970260e-8, 5.74108412545004946722e-8,
            -3.50196060308781257119e-7, 2.40648494783721712015e-6, -1.93619797416608296024e-5,
            1.95215518471351631108e-4, -2.85781685962277938680e-3, 1.03923736576817238437e-1, 2.72062619048444266945e0
        };

        public static readonly double[] GammaDk =
        {
            2.48574089138753565546e-5,
            1.05142378581721974210,
            -3.45687097222016235469,
            4.51227709466894823700,
            -2.98285225323576655721,
            1.05639711577126713077,
            -1.95428773191645869583e-1,
            1.70970543404441224307e-2,
            -5.71926117404305781283e-4,
            4.63399473359905636708e-6,
            -2.71994908488607703910e-9
        };

        public static readonly double[] ImpAn =
        {
            0.00337916709551257388990745, -0.00073695653048167948530905, -0.374732337392919607868241,
            0.0817442448733587196071743, -0.0421089319936548595203468, 0.0070165709512095756344528,
            -0.00495091255982435110337458, 0.000871646599037922480317225
        };

        public static readonly double[] ImpAd =
        {
            1, -0.218088218087924645390535, 0.412542972725442099083918, -0.0841891147873106755410271,
            0.0655338856400241519690695, -0.0120019604454941768171266, 0.00408165558926174048329689,
            -0.000615900721557769691924509
        };

        public static readonly double[] ImpBn =
        {
            -0.0361790390718262471360258, 0.292251883444882683221149, 0.281447041797604512774415,
            0.125610208862766947294894, 0.0274135028268930549240776, 0.00250839672168065762786937
        };


        public static readonly double[] ImpBd =
        {
            1, 1.8545005897903486499845, 1.43575803037831418074962, 0.582827658753036572454135,
            0.124810476932949746447682, 0.0113724176546353285778481
        };


        public static readonly double[] ImpCn =
        {
            -0.0397876892611136856954425, 0.153165212467878293257683, 0.191260295600936245503129,
            0.10276327061989304213645, 0.029637090615738836726027, 0.0046093486780275489468812,
            0.000307607820348680180548455
        };

        public static readonly double[] ImpCd =
        {
            1, 1.95520072987627704987886, 1.64762317199384860109595, 0.768238607022126250082483,
            0.209793185936509782784315, 0.0319569316899913392596356, 0.00213363160895785378615014
        };

        public static readonly double[] ImpDn =
        {
            -0.0300838560557949717328341, 0.0538578829844454508530552, 0.0726211541651914182692959,
            0.0367628469888049348429018, 0.00964629015572527529605267, 0.00133453480075291076745275,
            0.778087599782504251917881e-4
        };

        public static readonly double[] ImpDd =
        {
            1, 1.75967098147167528287343, 1.32883571437961120556307, 0.552528596508757581287907,
            0.133793056941332861912279, 0.0179509645176280768640766, 0.00104712440019937356634038,
            -0.106640381820357337177643e-7
        };

        public static readonly double[] ImpEn =
        {
            -0.0117907570137227847827732, 0.014262132090538809896674, 0.0202234435902960820020765,
            0.00930668299990432009042239, 0.00213357802422065994322516, 0.00025022987386460102395382,
            0.120534912219588189822126e-4
        };


        public static readonly double[] ImpEd =
        {
            1, 1.50376225203620482047419, 0.965397786204462896346934, 0.339265230476796681555511,
            0.0689740649541569716897427, 0.00771060262491768307365526, 0.000371421101531069302990367
        };


        public static readonly double[] ImpFn =
        {
            -0.00546954795538729307482955, 0.00404190278731707110245394, 0.0054963369553161170521356,
            0.00212616472603945399437862, 0.000394984014495083900689956, 0.365565477064442377259271e-4,
            0.135485897109932323253786e-5
        };


        public static readonly double[] ImpFd =
        {
            1, 1.21019697773630784832251, 0.620914668221143886601045, 0.173038430661142762569515,
            0.0276550813773432047594539, 0.00240625974424309709745382, 0.891811817251336577241006e-4,
            -0.465528836283382684461025e-11
        };


        public static readonly double[] ImpGn =
        {
            -0.00270722535905778347999196, 0.0013187563425029400461378, 0.00119925933261002333923989,
            0.00027849619811344664248235, 0.267822988218331849989363e-4, 0.923043672315028197865066e-6
        };


        public static readonly double[] ImpGd =
        {
            1, 0.814632808543141591118279, 0.268901665856299542168425, 0.0449877216103041118694989,
            0.00381759663320248459168994, 0.000131571897888596914350697, 0.404815359675764138445257e-11
        };


        public static readonly double[] ImpHn =
        {
            -0.00109946720691742196814323, 0.000406425442750422675169153, 0.000274499489416900707787024,
            0.465293770646659383436343e-4, 0.320955425395767463401993e-5, 0.778286018145020892261936e-7
        };

        public static readonly double[] ImpHd =
        {
            1, 0.588173710611846046373373, 0.139363331289409746077541, 0.0166329340417083678763028,
            0.00100023921310234908642639, 0.24254837521587225125068e-4
        };


        public static readonly double[] ImpIn =
        {
            -0.00056907993601094962855594, 0.000169498540373762264416984, 0.518472354581100890120501e-4,
            0.382819312231928859704678e-5, 0.824989931281894431781794e-7
        };

        public static readonly double[] ImpId =
        {
            1, 0.339637250051139347430323, 0.043472647870310663055044, 0.00248549335224637114641629,
            0.535633305337152900549536e-4, -0.117490944405459578783846e-12
        };


        public static readonly double[] ImpJn =
        {
            -0.000241313599483991337479091, 0.574224975202501512365975e-4, 0.115998962927383778460557e-4,
            0.581762134402593739370875e-6, 0.853971555085673614607418e-8
        };

        public static readonly double[] ImpJd =
        {
            1, 0.233044138299687841018015, 0.0204186940546440312625597, 0.000797185647564398289151125,
            0.117019281670172327758019e-4
        };


        public static readonly double[] ImpKn =
        {
            -0.000146674699277760365803642, 0.162666552112280519955647e-4, 0.269116248509165239294897e-5,
            0.979584479468091935086972e-7, 0.101994647625723465722285e-8
        };

        public static readonly double[] ImpKd =
        {
            1, 0.165907812944847226546036, 0.0103361716191505884359634, 0.000286593026373868366935721,
            0.298401570840900340874568e-5
        };

        public static readonly double[] ImpLn =
        {
            -0.583905797629771786720406e-4, 0.412510325105496173512992e-5, 0.431790922420250949096906e-6,
            0.993365155590013193345569e-8, 0.653480510020104699270084e-10
        };


        public static readonly double[] ImpLd =
        {
            1, 0.105077086072039915406159, 0.00414278428675475620830226, 0.726338754644523769144108e-4,
            0.477818471047398785369849e-6
        };

        public static readonly double[] ImpMn =
        {
            -0.196457797609229579459841e-4, 0.157243887666800692441195e-5, 0.543902511192700878690335e-7,
            0.317472492369117710852685e-9
        };


        public static readonly double[] ImpMd =
        {
            1, 0.052803989240957632204885, 0.000926876069151753290378112, 0.541011723226630257077328e-5,
            0.535093845803642394908747e-15
        };

        public static readonly double[] ImpNn =
        {
            -0.789224703978722689089794e-5, 0.622088451660986955124162e-6, 0.145728445676882396797184e-7,
            0.603715505542715364529243e-10
        };

        public static readonly double[] ImpNd =
            { 1, 0.0375328846356293715248719, 0.000467919535974625308126054, 0.193847039275845656900547e-5 };


        public static readonly double[] ErvInvImpAn =
        {
            -0.000508781949658280665617, -0.00836874819741736770379, 0.0334806625409744615033,
            -0.0126926147662974029034, -0.0365637971411762664006, 0.0219878681111168899165, 0.00822687874676915743155,
            -0.00538772965071242932965
        };


        public static readonly double[] ErvInvImpAd =
        {
            1, -0.970005043303290640362, -1.56574558234175846809, 1.56221558398423026363, 0.662328840472002992063,
            -0.71228902341542847553, -0.0527396382340099713954, 0.0795283687341571680018, -0.00233393759374190016776,
            0.000886216390456424707504
        };

        public static readonly double[] ErvInvImpBn =
        {
            -0.202433508355938759655, 0.105264680699391713268, 8.37050328343119927838, 17.6447298408374015486,
            -18.8510648058714251895, -44.6382324441786960818, 17.445385985570866523, 21.1294655448340526258,
            -3.67192254707729348546
        };

        public static readonly double[] ErvInvImpBd =
        {
            1, 6.24264124854247537712, 3.9713437953343869095, -28.6608180499800029974, -20.1432634680485188801,
            48.5609213108739935468, 10.8268667355460159008, -22.6436933413139721736, 1.72114765761200282724
        };

        public static readonly double[] ErvInvImpCn =
        {
            -0.131102781679951906451, -0.163794047193317060787, 0.117030156341995252019, 0.387079738972604337464,
            0.337785538912035898924, 0.142869534408157156766, 0.0290157910005329060432, 0.00214558995388805277169,
            -0.679465575181126350155e-6, 0.285225331782217055858e-7, -0.681149956853776992068e-9
        };


        public static readonly double[] ErvInvImpCd =
        {
            1, 3.46625407242567245975, 5.38168345707006855425, 4.77846592945843778382, 2.59301921623620271374,
            0.848854343457902036425, 0.152264338295331783612, 0.01105924229346489121
        };

        public static readonly double[] ErvInvImpDn =
        {
            -0.0350353787183177984712, -0.00222426529213447927281, 0.0185573306514231072324, 0.00950804701325919603619,
            0.00187123492819559223345, 0.000157544617424960554631, 0.460469890584317994083e-5,
            -0.230404776911882601748e-9, 0.266339227425782031962e-11
        };

        public static readonly double[] ErvInvImpDd =
        {
            1, 1.3653349817554063097, 0.762059164553623404043, 0.220091105764131249824, 0.0341589143670947727934,
            0.00263861676657015992959, 0.764675292302794483503e-4
        };

        public static readonly double[] ErvInvImpEn =
        {
            -0.0167431005076633737133, -0.00112951438745580278863, 0.00105628862152492910091,
            0.000209386317487588078668, 0.149624783758342370182e-4, 0.449696789927706453732e-6,
            0.462596163522878599135e-8, -0.281128735628831791805e-13, 0.99055709973310326855e-16
        };

        public static readonly double[] ErvInvImpEd =
        {
            1, 0.591429344886417493481, 0.138151865749083321638, 0.0160746087093676504695, 0.000964011807005165528527,
            0.275335474764726041141e-4, 0.282243172016108031869e-6
        };

        public static readonly double[] ErvInvImpFn =
        {
            -0.0024978212791898131227, -0.779190719229053954292e-5, 0.254723037413027451751e-4,
            0.162397777342510920873e-5, 0.396341011304801168516e-7, 0.411632831190944208473e-9,
            0.145596286718675035587e-11, -0.116765012397184275695e-17
        };

        public static readonly double[] ErvInvImpFd =
        {
            1, 0.207123112214422517181, 0.0169410838120975906478, 0.000690538265622684595676,
            0.145007359818232637924e-4, 0.144437756628144157666e-6, 0.509761276599778486139e-9
        };

        public static readonly double[] ErvInvImpGn =
        {
            -0.000539042911019078575891, -0.28398759004727721098e-6, 0.899465114892291446442e-6,
            0.229345859265920864296e-7, 0.225561444863500149219e-9, 0.947846627503022684216e-12,
            0.135880130108924861008e-14, -0.348890393399948882918e-21
        };

        public static readonly double[] ErvInvImpGd =
        {
            1, 0.0845746234001899436914, 0.00282092984726264681981, 0.468292921940894236786e-4,
            0.399968812193862100054e-6, 0.161809290887904476097e-8, 0.231558608310259605225e-11
        };

        public static double BesselI0(double x)
        {
            if (x < 0) x = -x;
            if (x <= 8.0)
            {
                var y = x / 2.0 - 2.0;
                return Math.Exp(x) * Evaluate.ChebyshevA(BesselI0A, y);
            }

            var x1 = 32.0 / x - 2.0;
            return Math.Exp(x) * Evaluate.ChebyshevA(BesselI0B, x1) / Math.Sqrt(x);
        }

        public static double BesselI1(double x)
        {
            var z = Math.Abs(x);
            if (z <= 8.0)
            {
                var y = z / 2.0 - 2.0;
                z = Evaluate.ChebyshevA(BesselI1A, y) * z * Math.Exp(z);
            }
            else
            {
                var x1 = 32.0 / z - 2.0;
                z = Math.Exp(z) * Evaluate.ChebyshevA(BesselI1B, x1) / Math.Sqrt(z);
            }

            if (x < 0.0) z = -z;
            return z;
        }

        public static double BesselK0(double x)
        {
            switch (x)
            {
                case <= 0.0:
                    throw new ArithmeticException();
                case <= 2.0:
                    {
                        var y = x * x - 2.0;
                        return Evaluate.ChebyshevA(BesselK0A, y) - Math.Log(0.5 * x) * BesselI0(x);
                    }
                default:
                    {
                        var z = 8.0 / x - 2.0;
                        return Math.Exp(-x) * Evaluate.ChebyshevA(BesselK0B, z) / Math.Sqrt(x);
                    }
            }
        }

        public static double BesselK0E(double x)
        {
            switch (x)
            {
                case <= 0.0:
                    throw new ArithmeticException();
                case <= 2.0:
                    {
                        var y = x * x - 2.0;
                        return Evaluate.ChebyshevA(BesselK0A, y) - Math.Log(0.5 * x) * BesselI0(x) * Math.Exp(x);
                    }
                default:
                    {
                        var x1 = 8.0 / x - 2.0;
                        return Evaluate.ChebyshevA(BesselK0B, x1) / Math.Sqrt(x);
                    }
            }
        }

        public static double BesselK1(double x)
        {
            var z = 0.5 * x;
            if (z <= 0.0) throw new ArithmeticException();

            if (x <= 2.0)
            {
                var y = x * x - 2.0;
                return Math.Log(z) * BesselI1(x) + Evaluate.ChebyshevA(BesselK1A, y) / x;
            }

            var x1 = 8.0 / x - 2.0;
            return Math.Exp(-x) * Evaluate.ChebyshevA(BesselK1B, x1) / Math.Sqrt(x);
        }

        public static double BesselK1E(double x)
        {
            switch (x)
            {
                case <= 0.0:
                    throw new ArithmeticException();
                case <= 2.0:
                    {
                        var y = x * x - 2.0;
                        return Math.Log(0.5 * x) * BesselI1(x) + Evaluate.ChebyshevA(BesselK1A, y) / x * Math.Exp(x);
                    }
                default:
                    {
                        var x1 = 8.0 / x - 2.0;
                        return Evaluate.ChebyshevA(BesselK1B, x1) / Math.Sqrt(x);
                    }
            }
        }

        public static Complex Hypotenuse(Complex a, Complex b)
        {
            if (a.Magnitude > b.Magnitude)
            {
                var r = b.Magnitude / a.Magnitude;
                return a.Magnitude * Math.Sqrt(1 + r * r);
            }

            if (b == 0.0) return 0d;
            {
                var r = a.Magnitude / b.Magnitude;
                return b.Magnitude * Math.Sqrt(1 + r * r);
            }
        }

        public static double Hypotenuse(double a, double b)
        {
            if (Math.Abs(a) > Math.Abs(b))
            {
                var r = b / a;
                return Math.Abs(a) * Math.Sqrt(1 + r * r);
            }

            if (b == 0.0) return 0d;
            {
                var r = a / b;
                return Math.Abs(b) * Math.Sqrt(1 + r * r);
            }
        }

        public static float Hypotenuse(float a, float b)
        {
            if (Math.Abs(a) > Math.Abs(b))
            {
                var r = b / a;
                return Math.Abs(a) * (float)Math.Sqrt(1 + r * r);
            }

            if (b == 0.0) return 0f;
            {
                var r = a / b;
                return Math.Abs(b) * (float)Math.Sqrt(1 + r * r);
            }
        }

        public static double Logistic(double p)
        {
            return 1.0 / (Math.Exp(-p) + 1.0);
        }

        public static double GeneralHarmonic(int n, double m)
        {
            double sum = 0;
            for (var i = 0; i < n; i++) sum += Math.Pow(i + 1, -m);

            return sum;
        }

        public static double DiGamma(double x)
        {
            const double c = 12.0;
            const double d1 = -0.57721566490153286;
            const double d2 = 1.6449340668482264365;
            const double s = 1e-6;
            const double s3 = 1.0 / 12.0;
            const double s4 = 1.0 / 120.0;
            const double s5 = 1.0 / 252.0;
            const double s6 = 1.0 / 240.0;
            const double s7 = 1.0 / 132.0;

            if (double.IsNegativeInfinity(x) || double.IsNaN(x)) return double.NaN;

            switch (x)
            {
                case <= 0 when Math.Floor(x).Equals(x):
                    return double.NegativeInfinity;
                case < 0:
                    return DiGamma(1.0 - x) + Math.PI / Math.Tan(-Math.PI * x);
                case <= s:
                    return d1 - 1 / x + d2 * x;
            }

            double result = 0;
            while (x < c)
            {
                result -= 1 / x;
                x++;
            }

            if (!(x >= c)) return result;
            var r = 1 / x;
            result += Math.Log(x) - 0.5 * r;
            r *= r;

            result -= r * (s3 - r * (s4 - r * (s5 - r * (s6 - r * s7))));

            return result;
        }

        public static double DiGammaInv(double p)
        {
            if (double.IsNaN(p)) return double.NaN;

            if (double.IsNegativeInfinity(p)) return 0.0;

            if (double.IsPositiveInfinity(p)) return double.PositiveInfinity;
            var x = Math.Exp(p);
            for (var d = 1.0; d > 1.0e-15; d /= 2.0) x += d * Math.Sign(p - DiGamma(x));
            return x;
        }

        public static double Erf(double x)
        {
            if (x == 0) return 0;

            if (double.IsPositiveInfinity(x)) return 1;

            if (double.IsNegativeInfinity(x)) return -1;

            return double.IsNaN(x) ? double.NaN : Imp(x, false);
        }

        public static double Erfc(double x)
        {
            if (x == 0) return 1;

            if (double.IsPositiveInfinity(x)) return 0;

            if (double.IsNegativeInfinity(x)) return 2;

            return double.IsNaN(x) ? double.NaN : Imp(x, true);
        }

        public static double Inv(double z)
        {
            switch (z)
            {
                case 0.0:
                    return 0.0;
                case >= 1.0:
                    return double.PositiveInfinity;
                case <= -1.0:
                    return double.NegativeInfinity;
            }

            double p, q, s;
            if (z < 0)
            {
                p = -z;
                q = 1 - p;
                s = -1;
            }
            else
            {
                p = z;
                q = 1 - z;
                s = 1;
            }

            return InvImpl(p, q, s);
        }

        private static double Imp(double z, bool invert)
        {
            if (z < 0)
            {
                if (!invert) return -Imp(-z, false);

                if (z < -0.5) return 2 - Imp(-z, true);

                return 1 + Imp(-z, false);
            }

            double result;

            if (z < 0.5)
            {
                if (z < 1e-10)
                    result = z * 1.125 + z * 0.003379167095512573896158903121545171688;
                else
                    result = z * 1.125 + z * Evaluate.Polynomial(z, ImpAn) / Evaluate.Polynomial(z, ImpAd);
            }
            else if (z < 110 || (z < 110 && invert))
            {
                invert = !invert;
                double r, b;
                switch (z)
                {
                    case < 0.75:
                        r = Evaluate.Polynomial(z - 0.5, ImpBn) / Evaluate.Polynomial(z - 0.5, ImpBd);
                        b = 0.3440242112F;
                        break;
                    case < 1.25:
                        r = Evaluate.Polynomial(z - 0.75, ImpCn) / Evaluate.Polynomial(z - 0.75, ImpCd);
                        b = 0.419990927F;
                        break;
                    case < 2.25:
                        r = Evaluate.Polynomial(z - 1.25, ImpDn) / Evaluate.Polynomial(z - 1.25, ImpDd);
                        b = 0.4898625016F;
                        break;
                    case < 3.5:
                        r = Evaluate.Polynomial(z - 2.25, ImpEn) / Evaluate.Polynomial(z - 2.25, ImpEd);
                        b = 0.5317370892F;
                        break;
                    case < 5.25:
                        r = Evaluate.Polynomial(z - 3.5, ImpFn) / Evaluate.Polynomial(z - 3.5, ImpFd);
                        b = 0.5489973426F;
                        break;
                    case < 8:
                        r = Evaluate.Polynomial(z - 5.25, ImpGn) / Evaluate.Polynomial(z - 5.25, ImpGd);
                        b = 0.5571740866F;
                        break;
                    case < 11.5:
                        r = Evaluate.Polynomial(z - 8, ImpHn) / Evaluate.Polynomial(z - 8, ImpHd);
                        b = 0.5609807968F;
                        break;
                    case < 17:
                        r = Evaluate.Polynomial(z - 11.5, ImpIn) / Evaluate.Polynomial(z - 11.5, ImpId);
                        b = 0.5626493692F;
                        break;
                    case < 24:
                        r = Evaluate.Polynomial(z - 17, ImpJn) / Evaluate.Polynomial(z - 17, ImpJd);
                        b = 0.5634598136F;
                        break;
                    case < 38:
                        r = Evaluate.Polynomial(z - 24, ImpKn) / Evaluate.Polynomial(z - 24, ImpKd);
                        b = 0.5638477802F;
                        break;
                    case < 60:
                        r = Evaluate.Polynomial(z - 38, ImpLn) / Evaluate.Polynomial(z - 38, ImpLd);
                        b = 0.5640528202F;
                        break;
                    case < 85:
                        r = Evaluate.Polynomial(z - 60, ImpMn) / Evaluate.Polynomial(z - 60, ImpMd);
                        b = 0.5641309023F;
                        break;
                    default:
                        r = Evaluate.Polynomial(z - 85, ImpNn) / Evaluate.Polynomial(z - 85, ImpNd);
                        b = 0.5641584396F;
                        break;
                }

                var g = Math.Exp(-z * z) / z;
                result = g * b + g * r;
            }
            else
            {
                result = 0;
                invert = !invert;
            }

            if (invert) result = 1 - result;

            return result;
        }

        public static double ErfcInv(double z)
        {
            switch (z)
            {
                case <= 0.0:
                    return double.PositiveInfinity;
                case >= 2.0:
                    return double.NegativeInfinity;
            }

            double p, q, s;
            if (z > 1)
            {
                q = 2 - z;
                p = 1 - q;
                s = -1;
            }
            else
            {
                p = 1 - z;
                q = z;
                s = 1;
            }

            return InvImpl(p, q, s);
        }

        public static double InvImpl(double p, double q, double s)
        {
            double result;

            if (p <= 0.5)
            {
                const float y = 0.0891314744949340820313f;
                var g = p * (p + 10);
                var r = Evaluate.Polynomial(p, ErvInvImpAn) / Evaluate.Polynomial(p, ErvInvImpAd);
                result = g * y + g * r;
            }
            else if (q >= 0.25)
            {
                const float y = 2.249481201171875f;
                var g = Math.Sqrt(-2 * Math.Log(q));
                var xs = q - 0.25;
                var r = Evaluate.Polynomial(xs, ErvInvImpBn) / Evaluate.Polynomial(xs, ErvInvImpBd);
                result = g / (y + r);
            }
            else
            {
                var x = Math.Sqrt(-Math.Log(q));
                switch (x)
                {
                    case < 3:
                        {
                            const float y = 0.807220458984375f;
                            var xs = x - 1.125;
                            var r = Evaluate.Polynomial(xs, ErvInvImpCn) / Evaluate.Polynomial(xs, ErvInvImpCd);
                            result = y * x + r * x;
                            break;
                        }
                    case < 6:
                        {
                            const float y = 0.93995571136474609375f;
                            var xs = x - 3;
                            var r = Evaluate.Polynomial(xs, ErvInvImpDn) / Evaluate.Polynomial(xs, ErvInvImpDd);
                            result = y * x + r * x;
                            break;
                        }
                    case < 18:
                        {
                            const float y = 0.98362827301025390625f;
                            var xs = x - 6;
                            var r = Evaluate.Polynomial(xs, ErvInvImpEn) / Evaluate.Polynomial(xs, ErvInvImpEd);
                            result = y * x + r * x;
                            break;
                        }
                    case < 44:
                        {
                            const float y = 0.99714565277099609375f;
                            var xs = x - 18;
                            var r = Evaluate.Polynomial(xs, ErvInvImpFn) / Evaluate.Polynomial(xs, ErvInvImpFd);
                            result = y * x + r * x;
                            break;
                        }
                    default:
                        {
                            const float y = 0.99941349029541015625f;
                            var xs = x - 44;
                            var r = Evaluate.Polynomial(xs, ErvInvImpGn) / Evaluate.Polynomial(xs, ErvInvImpGd);
                            result = y * x + r * x;
                            break;
                        }
                }
            }

            return s * result;
        }
    }

    public static class Evaluate
    {
        public static double Polynomial(double z, params double[] coefficients)
        {
            var sum = coefficients[^1];
            for (var i = coefficients.Length - 2; i >= 0; --i)
            {
                sum *= z;
                sum += coefficients[i];
            }

            return sum;
        }

        public static Complex Polynomial(Complex z, params double[] coefficients)
        {
            Complex sum = coefficients[^1];
            for (var i = coefficients.Length - 2; i >= 0; --i)
            {
                sum *= z;
                sum += coefficients[i];
            }

            return sum;
        }

        public static Complex Polynomial(Complex z, params Complex[] coefficients)
        {
            var sum = coefficients[^1];
            for (var i = coefficients.Length - 2; i >= 0; --i)
            {
                sum *= z;
                sum += coefficients[i];
            }

            return sum;
        }

        public static double Series(Func<double> nextSummand)
        {
            var compensation = 0.0;
            double current;
            const double factor = 1 << 16;

            var sum = nextSummand();

            do
            {
                current = nextSummand();
                var y = current - compensation;
                var t = sum + y;
                compensation = t - sum;
                compensation -= y;
                sum = t;
            } while (Math.Abs(sum) < Math.Abs(factor * current));

            return sum;
        }

        public static double ChebyshevA(double[] coefficients, double x)
        {
            double b2;

            var p = 0;

            var b0 = coefficients[p++];
            var b1 = 0.0;
            var i = coefficients.Length - 1;

            do
            {
                b2 = b1;
                b1 = b0;
                b0 = x * b1 - b2 + coefficients[p++];
            } while (--i > 0);

            return 0.5 * (b0 - b2);
        }

        public static double ChebyshevSum(int n, double[] coefficients, double x)
        {
            if (Math.Abs(x) < 0.6)
            {
                var u0 = 0.0;
                var u1 = 0.0;
                var u2 = 0.0;
                var xx = x + x;

                for (var i = n; i >= 0; i--)
                {
                    u2 = u1;
                    u1 = u0;
                    u0 = xx * u1 + coefficients[i] - u2;
                }

                return (u0 - u2) / 2.0;
            }

            if (x > 0.0)
            {
                var u1 = 0.0;
                var d1 = 0.0;
                var d2 = 0.0;
                var xx = x - 0.5 - 0.5;
                xx += xx;

                for (var i = n; i >= 0; i--)
                {
                    d2 = d1;
                    var u2 = u1;
                    d1 = xx * u2 + coefficients[i] + d2;
                    u1 = d1 + u2;
                }

                return (d1 + d2) / 2.0;
            }
            else
            {
                var u1 = 0.0;
                var d1 = 0.0;
                var d2 = 0.0;
                var xx = x + 0.5 + 0.5;
                xx += xx;
                for (var i = n; i >= 0; i--)
                {
                    d2 = d1;
                    var u2 = u1;
                    d1 = xx * u2 + coefficients[i] - d2;
                    u1 = d1 - u2;
                }

                return (d1 - d2) / 2.0;
            }
        }
    }

    #endregion

    #region Extend

    public static class Cryptography
    {
        [Obsolete("Encrypt")]
        public static byte[] Encrypt(byte[] data, string password, int keySize = 256)
        {
            using var aes = Aes.Create();
            aes.KeySize = keySize;
            aes.GenerateIV();
            aes.Key = new PasswordDeriveBytes(password, Array.Empty<byte>()).GetBytes(aes.KeySize / 8);

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var memoryStreamEncrypt = new MemoryStream();
            using var cryptoStream = new CryptoStream(memoryStreamEncrypt, encryptor, CryptoStreamMode.Write);

            cryptoStream.Write(data, 0, data.Length);
            cryptoStream.FlushFinalBlock();

            var encryptedData = memoryStreamEncrypt.ToArray();
            var cipherData = new byte[encryptedData.Length + aes.IV.Length];
            Array.Copy(aes.IV, 0, cipherData, 0, aes.IV.Length);
            Array.Copy(encryptedData, 0, cipherData, aes.IV.Length, encryptedData.Length);

            return cipherData;
        }

        [Obsolete("Decrypt")]
        public static byte[] Decrypt(byte[] data, string password, int keySize = 256)
        {
            using var aes = Aes.Create();
            aes.KeySize = keySize;
            aes.Key = new PasswordDeriveBytes(password, Array.Empty<byte>()).GetBytes(aes.KeySize / 8);

            var iv = new byte[aes.BlockSize / 8];
            var cipherData = new byte[data.Length - iv.Length];

            Array.Copy(data, 0, iv, 0, iv.Length);
            Array.Copy(data, iv.Length, cipherData, 0, cipherData.Length);

            aes.IV = iv;

            var decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            using var memoryStreamEncrypt = new MemoryStream(cipherData);
            using var cryptoStream = new CryptoStream(memoryStreamEncrypt, decryptor, CryptoStreamMode.Read);

            var plainCipherStream = new MemoryStream();
            cryptoStream.CopyTo(plainCipherStream);

            return plainCipherStream.ToArray();
        }

        public static string GenerateSecurePassword(int length)
        {
            var secureRandom = new RNGCryptoServiceProvider();
            var secureBytes = new byte[length];
            secureRandom.GetNonZeroBytes(secureBytes);

            return Convert.ToBase64String(secureBytes);
        }
    }

    public static class StringExtensionMethods
    {
        public enum TipoSimilitud
        {
            Ninguna,
            Igual,
            MayorLong,
            MenorLong
        }

        public const int MMaxDifToleradas = 2;


        public static readonly Regex MSplitWords = new(@"\W+");

        public static bool EqualsIgnoreCase(this string text, string toCheck)
        {
            return string.Equals(text, toCheck, StringComparison.OrdinalIgnoreCase);
        }

        public static bool EqualsToAnyIgnoreCase(this string text, params string[] toCheck)
        {
            if (toCheck == null)
                return false;

            return toCheck.Any(t => string.Equals(text, t, StringComparison.OrdinalIgnoreCase));
        }


        public static bool ContainsIgnoreCase(this string text, string toCheck)
        {
            if (toCheck.IsNullOrEmpty())
                throw new ArgumentException("El parametro 'toCheck' es vacio");

            return text.IndexOfIgnoreCase(toCheck) >= 0;
        }

        public static int IndexWholePhrase(this string text, string toCheck, int startIndex = 0)
        {
            if (toCheck.IsNullOrEmpty())
                throw new ArgumentException("El parametro 'toCheck' es vacio");

            while (startIndex <= text.Length)
            {
                var index = text.IndexOfIgnoreCase(startIndex, toCheck);
                if (index < 0)
                    return -1;

                var indexPreviousCar = index - 1;
                var indexNextCar = index + toCheck.Length;
                if ((index == 0
                     || !char.IsLetter(text[indexPreviousCar]))
                    && (index + toCheck.Length == text.Length
                        || !char.IsLetter(text[indexNextCar])))
                    return index;

                startIndex = index + toCheck.Length;
            }

            return -1;
        }

        public static string[] SplitInWords(this string s)
        {
            return MSplitWords.Split(s);
        }

        public static List<string> SplitInWordsLongerThan(this string s, int wordlength)
        {
            var splitwords = MSplitWords.Split(s);

            return splitwords.Where(word => word.Length > wordlength).ToList();
        }

        public static int TotalWords(this string text)
        {
            text = text.Trim();

            if (text.IsNullOrEmpty())
                return 0;

            var res = 0;

            var prevCharIsSeparator = true;
            foreach (var c in text)
                if (char.IsSeparator(c) || char.IsPunctuation(c) || char.IsWhiteSpace(c))
                {
                    if (!prevCharIsSeparator)
                        res++;
                    prevCharIsSeparator = true;
                }
                else
                {
                    prevCharIsSeparator = false;
                }

            if (!prevCharIsSeparator)
                res++;

            return res;
        }

        public static IEnumerable<string> EnumerateLines(this string s)
        {
            var index = 0;

            while (true)
            {
                var newIndex = s.IndexOf(Environment.NewLine, index, StringComparison.Ordinal);
                if (newIndex < 0)
                {
                    if (s.Length > index)
                        yield return s[index..];

                    yield break;
                }

                var currentString = s[index..(newIndex - index)];
                index = newIndex + 2;

                yield return currentString;
            }
        }


        public static int CountLines(this string s)
        {
            var index = 0;
            var lines = 0;

            while (true)
            {
                var newIndex = s.IndexOf(Environment.NewLine, index, StringComparison.Ordinal);
                if (newIndex < 0)
                {
                    if (s.Length > index)
                        lines++;

                    return lines;
                }

                index = newIndex + 2;
                lines++;
            }
        }

        public static string[] SplitInLines(this string s)
        {
            return s.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
        }

        public static T[] SplitInLinesTyped<T>(this string s) where T : IComparable
        {
            return SplitTyped<T>(s, Environment.NewLine);
        }

        public static string[] SplitInLinesRemoveEmptys(this string s)
        {
            return s.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        }


        public static Tuple<string, string> SplitByIndex(this string text, int index)
        {
            if (text.IsNullOrEmpty())
                return new Tuple<string, string>("", "");

            if (index >= text.Length)
                return new Tuple<string, string>(text, "");

            return index <= 0
                ? new Tuple<string, string>("", text)
                : new Tuple<string, string>(text[..(index - 1)], text[(index - 1)..]);
        }

        public static Tuple<string, string> SplitWordsByIndex(this string text, int index)
        {
            var splitByIndex = text.SplitByIndex(index);
            var res = new Tuple<string, string>(splitByIndex.Item1, splitByIndex.Item2);

            var wordsInItem1 = res.Item1.SplitInWords();
            res = new Tuple<string, string>(wordsInItem1.Take(wordsInItem1.Length - 1).JoinToString(" ").Trim(),
                wordsInItem1.Last() + splitByIndex.Item2);

            return res;
        }

        public static bool ContainsWholeWord(this string text, string toCheck)
        {
            if (text.IsNullOrEmpty())
                return false;

            if (toCheck.IsNullOrEmpty())
                throw new ArgumentException("El parametro 'toChek' es vacio");

            var partes = text.SplitInWords();
            return partes.Any(parte => parte.EqualsIgnoreCase(toCheck));
        }

        public static bool ContainsAnyWholeWord(this string text, params string[] toCheck)
        {
            if (text.IsNullOrEmpty())
                return false;

            if (toCheck == null || toCheck.Length == 0)
                throw new ArgumentException("El parametro 'toChek' es vacio");

            var partes = text.SplitInWords();
            return (from parte in partes from check in toCheck where parte.EqualsIgnoreCase(check) select parte).Any();
        }

        public static bool ContainsWholePhrase(this string text, string toCheck)
        {
            if (toCheck.IsNullOrEmpty())
                throw new ArgumentException("El parametro 'toChek' es vacio");

            var startIndex = 0;
            while (startIndex <= text.Length)
            {
                var index = text.IndexOfIgnoreCase(startIndex, toCheck);
                if (index < 0)
                    return false;

                var indexPreviousCar = index - 1;
                var indexNextCar = index + toCheck.Length;
                if ((index == 0
                     || !char.IsLetter(text[indexPreviousCar]))
                    && (index + toCheck.Length == text.Length
                        || !char.IsLetter(text[indexNextCar])))
                    return true;

                startIndex = index + toCheck.Length;
            }

            return false;
        }

        public static bool ContainsWholePhraseAny(this string text, params string[] toCheck)
        {
            return toCheck.Any(phrase => ContainsWholePhrase(text, phrase));
        }

        public static bool ContainsWholePhraseAll(this string text, params string[] toCheck)
        {
            return toCheck.All(text.ContainsWholePhrase);
        }

        public static string FindFirstPhrase(this string text, params string[] phrasesToCheck)
        {
            if (phrasesToCheck == null || phrasesToCheck.Length == 0)
                throw new ArgumentException("El parametro 'phrasesToCheck' es vacio");

            return phrasesToCheck.FirstOrDefault(text.ContainsWholePhrase);
        }

        public static bool IsSameWords(this string text, string check)
        {
            if (check.IsNullOrEmpty())
                return text.IsNullOrEmpty();

            var wordsText = text.SplitInWords();
            var wordsCheck = check.SplitInWords();

            var wordsTextNotInCheck = wordsText.FindAll(x => !x.IsOn(wordsCheck));
            if (wordsTextNotInCheck.Length > 0)
                return false;

            var wordsCheckNotInText = wordsCheck.FindAll(x => !x.IsOn(wordsText));
            return wordsCheckNotInText.Length <= 0;
        }

        public static bool ContainsAnyIgnoreCase(this string text, params string[] toCheck)
        {
            if (toCheck == null || toCheck.Length == 0)
                throw new ArgumentException("El parametro 'toChek' es vacio");

            return toCheck.Any(checking => text.IndexOfIgnoreCase(checking) >= 0);
        }

        public static bool ContainsAllIgnoreCase(this string text, params string[] toCheck)
        {
            if (toCheck == null || toCheck.Length == 0)
                throw new ArgumentException("El parametro 'toChek' es vacio");

            return toCheck.All(checking => text.IndexOfIgnoreCase(checking) >= 0);
        }

        public static bool ContainsOnlyThisChar(this string text, char toCheck)
        {
            return text.Length != 0 && text.All(t => t == toCheck);
        }


        public static int IndexOfIgnoreCase(this string text, string toCheck)
        {
            return text.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase);
        }

        public static int LastIndexOfIgnoreCase(this string text, string toCheck)
        {
            return text.LastIndexOf(toCheck, StringComparison.OrdinalIgnoreCase);
        }


        public static int LastIndexOfIgnoreCase(this string text, string toCheck, int startIndex, int count)
        {
            return text.LastIndexOf(toCheck, startIndex, count, StringComparison.OrdinalIgnoreCase);
        }

        public static int IndexOfIgnoreCase(this string text, int startIndex, string toCheck)
        {
            return text.IndexOf(toCheck, startIndex, StringComparison.OrdinalIgnoreCase);
        }

        public static string FindFirstOcurrence(this string text, params string[] toCheck)
        {
            if (toCheck == null || toCheck.Length == 0)
                throw new ArgumentException("El parametro 'toCheck' es vacio");

            return toCheck.FirstOrDefault(text.ContainsIgnoreCase);
        }

        public static int LastIndexOfAny(this string text, params string[] toCheck)
        {
            if (toCheck == null || toCheck.Length == 0)
                throw new ArgumentException("El parametro 'toCheck' es vacio");

            var res = -1;
            foreach (var checking in toCheck)
            {
                var index = text.LastIndexOf(checking, StringComparison.OrdinalIgnoreCase);
                if (index >= 0
                    && index > res)
                    res = index;
            }

            return res;
        }


        public static string FindAndReplaceFirstOcurrence(this string text, string newValue, params string[] oldValues)
        {
            if (oldValues == null || oldValues.Length == 0)
                throw new ArgumentException("El parametro 'oldValues' es vacio");

            foreach (var oldValue in oldValues)
                if (text.ContainsIgnoreCase(oldValue))
                    return text.ReplaceIgnoringCase(oldValue, newValue);
            return text;
        }

        public static string FindAndInsertBeforeFirstOcurrence(this string text, string textInsert,
            params string[] oldValues)
        {
            if (oldValues == null || oldValues.Length == 0)
                throw new ArgumentException("El parametro 'oldValues' es vacio");

            foreach (var oldValue in oldValues)
                if (text.ContainsIgnoreCase(oldValue))
                    return text.ReplaceIgnoringCase(oldValue, textInsert + oldValue);
            return text;
        }

        public static bool StartsWithIgnoreCase(this string text, string toCheck)
        {
            if (toCheck.IsNullOrEmpty())
                return true;

            return text.IsNullOrEmpty()
                ? toCheck.IsNullOrEmpty()
                : text.StartsWith(toCheck, StringComparison.OrdinalIgnoreCase);
        }

        public static bool StartsWithAnyIgnoreCase(this string text, params string[] toCheck)
        {
            return StartsWithAnyIgnoreCase(text, (IEnumerable<string>)toCheck);
        }

        public static bool StartsWithAnyIgnoreCase(this string text, IEnumerable<string> toCheck)
        {
            return !text.IsNullOrEmpty() &&
                   toCheck.Any(check => text.StartsWith(check, StringComparison.OrdinalIgnoreCase));
        }

        public static bool EndsWithIgnoreCase(this string text, string toCheck)
        {
            if (toCheck.IsNullOrEmpty())
                return true;

            return text.IsNullOrEmpty()
                ? toCheck.IsNullOrEmpty()
                : text.EndsWith(toCheck, StringComparison.OrdinalIgnoreCase);
        }

        public static bool EndsWithAnyIgnoreCase(this string text, params string[] toCheck)
        {
            return EndsWithAnyIgnoreCase(text, (IEnumerable<string>)toCheck);
        }

        public static bool EndsWithAnyIgnoreCase(this string text, IEnumerable<string> toCheck)
        {
            return !text.IsNullOrEmpty() &&
                   toCheck.Any(check => text.EndsWith(check, StringComparison.OrdinalIgnoreCase));
        }

        public static string ToLink(this string text, string href, string target = "")
        {
            return "<a href='" + href + "' " + (target.IsNullOrEmpty() ? "" : " target='" + target + "'") + ">" + text +
                   "</a>";
        }


        public static string RemoveFromIgnoreCase(this string text, string removeFromThis)
        {
            var index = text.IndexOfIgnoreCase(removeFromThis);

            return index < 0 ? text : text[..index];
        }

        public static bool NotIsNullOrEmpty(this string texto)
        {
            return !IsNullOrEmpty(texto);
        }

        public static bool IsNullOrWhite(this string texto)
        {
            if (IsNullOrEmpty(texto))
                return true;

            texto = texto.Trim();
            return IsNullOrEmpty(texto);
        }

        public static bool NotIsNullOrWhite(this string texto)
        {
            return !texto.IsNullOrWhite();
        }

        public static bool IsEmpty(this string texto)
        {
            return texto.Equals(Empty);
        }

        public static string Substring(this string text, string startText)
        {
            var indice = startText.IndexOf(text, StringComparison.Ordinal);
            if (indice == -1) throw new ArgumentException("No se encontro: " + startText);
            return text[indice..];
        }

        public static string Right(this string text, int length)
        {
            if (length < 0) throw new ArgumentException("Length > 0", nameof(length));
            if (length == 0 || text == null) return "";
            var strLength = text.Length;
            return length >= strLength ? text : text.Substring(strLength - length, length);
        }

        public static string Left(this string text, int length)
        {
            if (length < 0) throw new ArgumentException("Length > 0", nameof(length));
            if (length == 0 || text == null) return "";
            return length >= text.Length ? text : text[..length];
        }

        public static bool Contains(this string text, string[] values)
        {
            var contain = false;
            foreach (var s in values)
                if (text.Contains(s))
                    contain = true;
            return contain;
        }

        public static void TrimAll(this IList<string> textos)
        {
            for (var i = 0; i < textos.Count; i++) textos[i] = textos[i].Trim();
        }

        public static string Fill(this string original, params object[] values)
        {
            var texto =
                original.Replace("\\n", Environment.NewLine)
                    .Replace("<br>", Environment.NewLine)
                    .Replace("<BR>", Environment.NewLine);

            return Format(texto, values);
        }

        public static string ReplaceIgnoringCase(this string original, string oldValue, string newValue)
        {
            return Replace(original, oldValue, newValue, StringComparison.OrdinalIgnoreCase);
        }

        public static string ReplaceOnlyWholePhrase(this string original, string oldValue, string newValue)
        {
            if (original.IsNullOrEmpty()
                || oldValue.IsNullOrEmpty())
                return original;

            var index = original.IndexWholePhrase(oldValue);
            var lastIndex = 0;

            var buffer = new StringBuilder(original.Length);

            while (index >= 0)
            {
                buffer.Append(original, lastIndex, index - lastIndex);
                buffer.Append(newValue);

                lastIndex = index + oldValue.Length;

                index = original.IndexWholePhrase(oldValue, index + 1);
            }

            buffer.Append(original, lastIndex, original.Length - lastIndex);

            return buffer.ToString();
        }

        public static string ReplaceFirstOccurrence(this string original, string oldValue, string newValue)
        {
            if (oldValue.IsNullOrEmpty())
                return original;

            var index = original.IndexOfIgnoreCase(oldValue);

            return index switch
            {
                < 0 => original,
                0 => newValue + original[oldValue.Length..],
                _ => original[..index] + newValue + original[(index + oldValue.Length)..]
            };
        }

        public static string ReplaceLastOccurrence(this string original, string oldValue, string newValue)
        {
            if (oldValue.IsNullOrEmpty())
                return original;

            var index = original.LastIndexOfIgnoreCase(oldValue);

            return index switch
            {
                < 0 => original,
                0 => newValue + original[oldValue.Length..],
                _ => original[..index] + newValue + original[(index + oldValue.Length)..]
            };
        }

        public static string ReplaceOnlyAtEndIgnoreCase(this string original, string oldValue, string newValue)
        {
            if (oldValue.IsNullOrEmpty())
                return original;

            if (original.EndsWithIgnoreCase(oldValue))
                return original[..^oldValue.Length] + newValue;

            return original;
        }


        public static string Replace(this string original, string oldValue, string newValue,
            StringComparison comparisionType)
        {
            if (original.IsNullOrEmpty())
                return original;

            var result = original;

            if (IsNullOrEmpty(oldValue)) return result;
            var index = -1;
            var lastIndex = 0;

            var buffer = new StringBuilder(original.Length);

            while ((index = original.IndexOf(oldValue, index + 1, comparisionType)) >= 0)
            {
                buffer.Append(original, lastIndex, index - lastIndex);
                buffer.Append(newValue);

                lastIndex = index + oldValue.Length;
            }

            buffer.Append(original, lastIndex, original.Length - lastIndex);

            result = buffer.ToString();

            return result;
        }

        public static string Truncate(this string original, int maxLength)
        {
            if (original.IsNullOrEmpty() || maxLength == 0)
                return Empty;
            if (original.Length <= maxLength)
                return original;
            if (maxLength <= 3)
                return original[..2] + ".";
            return original[..(maxLength - 3)] + "...";
        }

        public static string ReplaceRecursive(this string original, string oldValue, string newValue)
        {
            const int maxTries = 1000;

            string ante;

            var res = original.Replace(oldValue, newValue);

            var i = 0;
            do
            {
                i++;
                ante = res;
                res = ante.Replace(oldValue, newValue);
            } while (ante != res || i > maxTries);

            return res;
        }

        public static string ToCamelCase(this string original)
        {
            if (original.Length <= 1)
                return original.ToLower();

            return char.ToLower(original[0]) + original[1..];
        }

#if !SILVERLIGHT
        public static string UseAsSeparatorFor<T>(this string separator, IEnumerable<T> list)
        {
            return list.JoinToString(separator);
        }
#endif
        public static string AvoidNull(this string original)
        {
            return original ?? Empty;
        }

        public static string Repeat(this string text, int times)
        {
            if (text.IsEmpty() || times == 0)
                return Empty;

            if (text.Length == 1)
                return new string(text[0], times);

            switch (times)
            {
                case 1:
                    return text;
                case 2:
                    return Concat(text, text);
                case 3:
                    return Concat(text, text, text);
                case 4:
                    return Concat(text, text, text, text);
            }

            var res = new StringBuilder(text.Length * times);
            for (var i = 0; i < times; i++) res.Append(text);
            return res.ToString();
        }

        public static string ExtractAround(this string text, int index, int left, int right)
        {
            if (text.IsNullOrEmpty())
                return Empty;

            if (index >= text.Length)
                throw new IndexOutOfRangeException("The parameter index is outside the limits of the string.");

            var startIndex = Math.Max(0, index - left);
            var length = Math.Min(text.Length - startIndex, index - startIndex + right);

            return text.Substring(startIndex, length);
        }


        public static string TrimPhrase(this string text, string phrase)
        {
            var res = TrimPhraseStart(text, phrase);
            res = TrimPhraseEnd(res, phrase);
            return res;
        }

        public static string TrimPhraseStart(this string text, string phrase)
        {
            if (text.IsNullOrEmpty())
                return Empty;

            if (phrase.IsNullOrEmpty())
                return text;

            while (text.StartsWith(phrase)) text = text[phrase.Length..];

            return text;
        }

        public static string TrimPhraseEnd(this string text, string phrase)
        {
            if (text.IsNullOrEmpty())
                return Empty;

            if (phrase.IsNullOrEmpty())
                return text;

            while (text.EndsWithIgnoreCase(phrase)) text = text[..^phrase.Length];

            return text;
        }


        public static bool IsNumber(this string original)
        {
            return long.TryParse(original, out _);
        }


        public static bool Like(this string me, string pattern)
        {
            var regex = new Regex("^" + pattern
                                          .Replace(".", "\\.")
                                          .Replace("*", ".*")
                                          .Replace("%", ".*")
                                          .Replace("\\.*", "\\%")
                                      + "$", RegexOptions.IgnoreCase);

            return regex.IsMatch(me);
        }


        public static bool MatchRegEx(this string me, string pattern)
        {
            return Regex.IsMatch(me, pattern, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);
        }


        public static string RemoveDuplicateSpaces(this string me)
        {
            if (me.IsNullOrEmpty())
                return me;

            string ante = null;
            while (ante != me)
            {
                ante = me;
                me = me.Replace("  ", " ");
            }

            return me;
        }

        public static string RemoveDuplicateChar(this string me, char charRemove)
        {
            if (me.IsNullOrEmpty())
                return me;

            var strChar = charRemove.ToString();
            var charRep = strChar + strChar;

            string ante = null;
            while (ante != me)
            {
                ante = me;
                me = me.Replace(charRep, strChar);
            }

            return me;
        }

        public static string LastWord(this string me)
        {
            if (me.IsNullOrEmpty())
                return Empty;

            for (var i = me.Length - 1; i >= 0; i--)
                if (char.IsSeparator(me, i))
                    return i == me.Length - 1 ? Empty : me[(i + 1)..];

            return me;
        }
#if !SILVERLIGHT
        public static string SecondWord(this string me)
        {
            if (me.IsNullOrEmpty())
                return Empty;

            var parts = me.SplitInWords();
            return parts.Length >= 2 ? parts[1] : Empty;
        }
#endif

        public static string FirstWord(this string me)
        {
            if (me.IsNullOrEmpty())
                return Empty;

            for (var i = 0; i < me.Length; i++)
                if (char.IsSeparator(me, i))
                    return i == 0 ? Empty : me[..i];

            return me;
        }

        public static string RemoveChars(this string me, params char[] toRemove)
        {
            var res = new StringBuilder(me);
            foreach (var remove in toRemove) res.Replace(remove, char.MinValue);
            res.Replace(char.MinValue.ToString(), Empty);
            return res.ToString();
        }

        public static string ReplaceCharsWithSpace(this string me, params char[] toReplace)
        {
            var res = new StringBuilder(me);
            foreach (var replace in toReplace) res.Replace(replace, ' ');
            return res.ToString();
        }

        public static string ReplaceNumbersWith(this string me, char toReplace)
        {
            var res = new StringBuilder(me.Length);
            foreach (var caracter in me)
                res.Append(caracter.IsOn('1', '2', '3', '4', '5', '6', '7', '8', '9', '0') ? toReplace : caracter);
            return res.ToString();
        }

        public static string SubstringFrom(this string me, string from)
        {
            if (me.IsNullOrEmpty())
                return Empty;

            var index = me.IndexOfIgnoreCase(from);
            return index < 0 ? Empty : me[(index + from.Length)..];
        }

        public static string SubstringTo(this string me, string from)
        {
            if (me.IsNullOrEmpty())
                return Empty;

            var index = me.IndexOfIgnoreCase(from);
            return index < 0 ? Empty : me[..index];
        }

        public static int CountOccurrences(this string text, char toCheck)
        {
            return text.CountOccurrences(toCheck.ToString());
        }

        public static int CountOccurrences(this string text, string toCheck)
        {
            if (toCheck.IsNullOrEmpty())
                return 0;

            var res = 0;
            var posIni = 0;
            while ((posIni = text.IndexOfIgnoreCase(posIni, toCheck)) != -1)
            {
                posIni += toCheck.Length;
                res++;
            }

            return res;
        }

        public static bool DiffOnlyOneChar(this string text, string toCheck)
        {
            if (text.Length != toCheck.Length)
                throw new ArgumentException("Los parametros para DiffOnlyOneChar deben tener la misma longitud");

            return text.DiffCharsCount(toCheck) == 1;
        }

        public static int DiffCharsCount(this string text, string toCheck)
        {
            if (text.Length != toCheck.Length)
                throw new ArgumentException("Los parametros para DiffOnlyOneChar deben tener la misma longitud");

            return text.Where((t, i) => t != toCheck[i]).Count();
        }

        public static int DiffCharsCountIgnoreCase(this string text, string toCheck)
        {
            if (text.Length != toCheck.Length)
                throw new ArgumentException("Los parametros para DiffOnlyOneChar deben tener la misma longitud");

            var res = 0;
            for (var i = 0; i < text.Length; i++)
                if (!text[i].EqualsIgnoreCase(toCheck[i]))
                    res++;
            return res;
        }

        public static bool OneAbsentChar(this string text, string toCheck)
        {
            if (text.Length > 1
                && toCheck.Length > 1
                && Math.Abs(text.Length - toCheck.Length) != 1)
                return false;

            var textWithChar = text.Length > toCheck.Length ? text : toCheck;
            var textNoChar = text.Length > toCheck.Length ? toCheck : text;

            if (textWithChar[^1] != textNoChar[^1])
                return textWithChar[..^1].EqualsIgnoreCase(textNoChar);

            for (var i = 0; i < textNoChar.Length; i++)
                if (textWithChar[i] != textNoChar[i])
                    return textWithChar[(i + 1)..].EqualsIgnoreCase(textNoChar[i..]);
            return false;
        }

        public static double EvaluarSimilitud(this string text, string toCheck, double similitudMinima)
        {
            const int difEncontradas = 0;
            return EvaluarSimilitud(text, toCheck, similitudMinima, difEncontradas);
        }

        public static double EvaluarSimilitud(this string text, string toCheck, double similitudMinima,
            int difEncontradas)
        {
            if (difEncontradas >= MMaxDifToleradas)
                return 0.0;


            text = text.RemoveChars(' ');
            toCheck = toCheck.RemoveChars(' ');

            if (text.EqualsIgnoreCase(toCheck))
                return 1;


            var porcionText = text;
            var porcionToCheck = toCheck;
            if (text.Length != toCheck.Length)
            {
                if (text.Length > toCheck.Length)
                    porcionText = text[..toCheck.Length];
                else if (toCheck.Length > text.Length)
                    porcionToCheck = toCheck[..text.Length];
                if (porcionText.EqualsIgnoreCase(porcionToCheck))
                    return 0.75;
            }


            var totalDiferencias = 0;
            var posDiferencia = -1;
            for (var i = 0; i < text.Length; i++)
            {
                if (i >= toCheck.Length
                    || text.ToCharArray()[i] != toCheck.ToCharArray()[i])
                    totalDiferencias++;
                if (posDiferencia < 0 && totalDiferencias == 1)
                    posDiferencia = i;
            }

            var res = Convert.ToDouble(text.Length - totalDiferencias) / Convert.ToDouble(text.Length);

            if (totalDiferencias <= MMaxDifToleradas)
                return res;


            var diferencias = difEncontradas + 1;

            var resConCarAusenteEnTexto2 = text[(posDiferencia + 1)..]
                .EvaluarSimilitud(toCheck[posDiferencia..], similitudMinima, diferencias);

            var resConCarAusenteEnTexto1 = text[posDiferencia..]
                .EvaluarSimilitud(toCheck[(posDiferencia + 1)..], similitudMinima, diferencias);

            var resConCarCambiado = text[(posDiferencia + 1)..]
                .EvaluarSimilitud(toCheck[(posDiferencia + 1)..], similitudMinima, diferencias);

            if (resConCarAusenteEnTexto2 > similitudMinima
                || resConCarAusenteEnTexto1 > similitudMinima
                || resConCarCambiado > similitudMinima)
                return (1.0 +
                        Math.Max(resConCarAusenteEnTexto2, Math.Max(resConCarAusenteEnTexto1, resConCarCambiado)) -
                        0.10) /
                       2.0;

            return res;
        }

        public static TipoSimilitud EvaluarTipoSimilitud(this string text, string toCheck)
        {
            text = text.RemoveChars(' ');
            toCheck = toCheck.RemoveChars(' ');


            if (text.EqualsIgnoreCase(toCheck))
                return TipoSimilitud.Igual;

            var porcionText = text;
            var porcionToCheck = toCheck;
            if (text.Length == toCheck.Length) return TipoSimilitud.Ninguna;
            if (text.Length > toCheck.Length)
                porcionText = text[..toCheck.Length];
            else if (toCheck.Length > text.Length)
                porcionToCheck = toCheck[..text.Length];
            if (porcionText.EqualsIgnoreCase(porcionToCheck))
                return text.Length > toCheck.Length ? TipoSimilitud.MayorLong : TipoSimilitud.MenorLong;

            return TipoSimilitud.Ninguna;
        }


        public static string RemoveAcentosIgnoreCaseAndÑ(this string text)
        {
            return text.IsNullOrEmpty() ? text : text.RemoveAcentosIgnoreCase().Replace('Ñ', 'N').Replace('ñ', 'n');
        }

        public static string RemoveAcentosIgnoreCase(this string text)
        {
            if (text.IsNullOrEmpty())
                return text;

            return text.Replace('Á', 'A')
                .Replace('É', 'E')
                .Replace('Í', 'I')
                .Replace('Ó', 'O')
                .Replace('Ú', 'U')
                .Replace('ü', 'u')
                .Replace('Ü', 'U')
                .Replace('á', 'a')
                .Replace('é', 'e')
                .Replace('í', 'i')
                .Replace('ó', 'o')
                .Replace('ú', 'u');
        }

        public static string SafeGroupValue(this Match match, string name)
        {
            var group = match.Groups[name];

            return group == null ? null : match.Groups[name].Value;
        }

#if !SILVERLIGHT
        public static string ToValidIdentifier(this string original)
        {
            original = original.ToCapitalCase();

            if (original.Length == 0)
                return "_";

            var res = new StringBuilder(original.Length + 1);
            if (!char.IsLetter(original[0]) && original[0] != '_')
                res.Append('_');

            foreach (var c in original)
                if (char.IsLetterOrDigit(c) || c == '_')
                    res.Append(c);
                else
                    res.Append('_');

            return res.ToString().ReplaceRecursive("__", "_").Trim('_');
        }


        public static string ToCapitalCase(this string original)
        {
            var words = original.Split(' ');
            var result = new List<string>();
            foreach (var word in words)
                if (word.Length == 0 || AllCapitals(word))
                    result.Add(word);
                else if (word.Length == 1)
                    result.Add(word.ToUpper());
                else
                    result.Add(char.ToUpper(word[0]) + word.Remove(0, 1).ToLower());

            return Join(" ", result).Replace(" Y ", " y ")
                .Replace(" De ", " de ")
                .Replace(" O ", " o ");
        }

        private static bool AllCapitals(string input)
        {
            return input.ToCharArray().All(char.IsUpper);
        }


#endif

#if !SILVERLIGHT
        public static T[] SplitTyped<T>(this string me, char delimiter)
            where T : IComparable
        {
            if (me.IsNullOrWhite())
                return new T[] { };

            me = me.Trim();

            var parts = me.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

            var res = new T[parts.Length];

            for (var i = 0; i < parts.Length; i++) res[i] = (T)Convert.ChangeType(parts[i], typeof(T));
            return res;
        }

        public static T[] SplitTyped<T>(this string me, string delimiter)
            where T : IComparable
        {
            if (me.IsNullOrWhite())
                return new T[] { };

            me = me.Trim();

            var parts = me.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

            var res = new T[parts.Length];

            for (var i = 0; i < parts.Length; i++) res[i] = (T)Convert.ChangeType(parts[i], typeof(T));
            return res;
        }
#endif

        #region Contains digits and letters revisar redundancias

        public static string OnlyLettersNumbers(this string text)
        {
            var res = new StringBuilder(text.Length);

            foreach (var car in text.Where(char.IsLetterOrDigit))
                res.Append(car);

            return res.ToString();
        }

        public static string FilterChars(this string text, Predicate<char> onlyThese)
        {
            var res = new StringBuilder(text.Length);

            foreach (var car in text.Where(car => onlyThese(car)))
                res.Append(car);

            return res.ToString();
        }


        public static bool IsUpper(this string text)
        {
            return text.All(ch => char.IsLetter(ch) && !char.IsLower(ch));
        }

        public static bool IsLower(this string text)
        {
            return text.All(ch => !char.IsLetter(ch) || !char.IsUpper(ch));
        }

        public static bool ContainsOnlyDigits(this string text)
        {
            return text.All(car => char.IsDigit(car));
        }

        public static string OnlyDigits(this string text)
        {
            return text.OnlyDigits(null);
        }

        public static bool NotContainsDigits(this string text)
        {
            return text.All(car => !char.IsDigit(car));
        }

        public static bool ContainsDigit(this string text)
        {
            return text.Any(char.IsDigit);
        }

        public static string OnlyDigits(this string text, IEnumerable<char> excepciones)
        {
            var res = new StringBuilder();
            foreach (var car in text.Where(car => char.IsDigit(car)
                                                  || excepciones.Contains(car)))
                res.Append(car);

            return res.ToString();
        }

        public static bool IncludeDigits(this string text)
        {
            return text.IncludeDigits(0);
        }

        public static bool IncludeDigits(this string text, int minCount)
        {
            var count = 0;
            foreach (var car in text)
            {
                if (char.IsDigit(car))
                    count++;

                if (count >= minCount)
                    return true;
            }

            return false;
        }

        public static bool IncludeLetters(this string text)
        {
            return text.IncludeLetters(0);
        }

        public static bool IncludeLetters(this string text, int minCount)
        {
            var count = 0;
            foreach (var car in text)
            {
                if (char.IsLetter(car))
                    count++;

                if (count >= minCount)
                    return true;
            }

            return false;
        }

        public static int TotalDigits(this string text)
        {
            return text.IsNullOrEmpty() ? 0 : text.ToCharArray().FindAll(char.IsDigit).Length;
        }

        public static int TotalLetters(this string text)
        {
            return text.IsNullOrEmpty() ? 0 : text.ToCharArray().FindAll(char.IsLetter).Length;
        }

        public static int TotalLowerLetters(this string text)
        {
            return text.IsNullOrEmpty()
                ? 0
                : text.ToCharArray().FindAll(x => char.IsLetter(x) && char.IsLower(x)).Length;
        }

        public static int TotalUpperLetters(this string text)
        {
            return text.IsNullOrEmpty()
                ? 0
                : text.ToCharArray().FindAll(x => char.IsLetter(x) && char.IsUpper(x)).Length;
        }

        #endregion


        #region "  Char Extensions  "

        public static bool EqualsIgnoreCase(this char text, char toCheck)
        {
            return char.ToUpper(text) == char.ToUpper(toCheck);
        }

        public static bool EqualsIgnoreCase(this char? text, char toCheck)
        {
            if (text == null)
                return false;

            return char.ToUpper(text.Value) == char.ToUpper(toCheck);
        }

        public static int AsciiValue(this char c)
        {
            var num2 = Convert.ToInt32(c);
            if (num2 < 0x80) return num2;

            byte[] buffer;
            var fileIoEncoding = Encoding.UTF8;

            char[] chars = { c };
            if (fileIoEncoding.GetMaxByteCount(1) == 1)
            {
                buffer = new byte[1];
                fileIoEncoding.GetBytes(chars, 0, 1, buffer, 0);
                return buffer[0];
            }

            buffer = new byte[2];
            if (fileIoEncoding.GetBytes(chars, 0, 1, buffer, 0) == 1) return buffer[0];
            if (BitConverter.IsLittleEndian) (buffer[0], buffer[1]) = (buffer[1], buffer[0]);

            int num = BitConverter.ToInt16(buffer, 0);

            return num;
        }

        #endregion
    }

    public static class FormatValidationExtension
    {
        public static bool IsValidEmailFormat(this string value)
        {
            if (IsNullOrEmpty(value)) return false;
            var index = value.IndexOf('@');

            return
                index > 0 &&
                index != value.Length - 1 &&
                index == value.LastIndexOf('@');
        }

        public static bool IsValidCreditCardNumber(this string value)
        {
            if (IsNullOrEmpty(value)) return false;

            value = value.Replace("-", "").Replace(" ", "");

            var checksum = 0;
            var evenDigit = false;
            foreach (var digit in value.ToCharArray().Reverse())
            {
                if (!char.IsDigit(digit)) return false;

                var digitValue = (digit - '0') * (evenDigit ? 2 : 1);
                evenDigit = !evenDigit;

                while (digitValue > 0)
                {
                    checksum += digitValue % 10;
                    digitValue /= 10;
                }
            }

            return checksum % 10 == 0;
        }

        public static bool IsValidDateTime(this DateTime? date)
        {
            return date != default;
        }

        public static bool IsValidDateTime(this DateTime date)
        {
            return date != default;
        }

        public static bool IsValidDateTimeString(this string date)
        {
            return date.ToDateTime() != default;
        }

        public static bool IsFutureDate(this string date)
        {
            return date.ToDateTime() >= DateTime.Today;
        }

        public static bool IsValidStandardDateString(this string value)
        {
            return DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None,
                out _);
        }

        public static bool IsNumber(this string value)
        {
            return Regex.IsMatch(value, @"^\d+$");
        }

        public static bool IsWholeNumber(this string value)
        {
            return long.TryParse(value, out _);
        }

        public static bool IsDecimalNumber(this string value)
        {
            return decimal.TryParse(value, out _);
        }

        public static bool IsBoolean(this string value)
        {
            return bool.TryParse(value, out var _);
        }

        public static bool IsHtml(this string value)
        {
            return Regex.IsMatch(value, @"<\s*([^ >]+)[^>]*>.*?<\s*/\s*\1\s*>");
        }

        public static bool IsAlphaNumeric(this string value)
        {
            return value.All(char.IsLetterOrDigit);
        }

        public static bool IsAlphaNumericStrict(this string value)
        {
            return value.All(c => (c >= 48 && c <= 57) || (c >= 65 && c <= 90) || (c >= 97 && c <= 122));
        }
    }

    public static class ValueHandlingValidationExtension
    {
        public static T Null<T>([NotNull] T input,
            [NotNull] string parameterName)
        {
            if (input is null) throw new ArgumentException($"The given input {parameterName} was null.", parameterName);

            return input;
        }

        public static bool False(bool input,
            [NotNull] string message)
        {
            if (!input) throw new InvalidOperationException(message);

            return true;
        }

        public static bool True(bool input,
            [NotNull] string message)
        {
            if (input) throw new InvalidOperationException(message);

            return false;
        }

        public static void NotDefined<T>(
            [NotNull] object input)
            where T : Enum
        {
            if (!Enum.IsDefined(typeof(T), input))
                throw new ArgumentException("The given input is not defined or does not exist.");
        }
    }

    public interface IValueValidatorClause
    {
    }

    public class ValueValidator : IValueValidatorClause
    {
        private ValueValidator()
        {
        }

        public static IValueValidatorClause ThrowsWhen { get; } = new ValueValidator();
    }

    public static class TypeConverterExtension
    {
        public static DateTime ToDateTime(this string value)
        {
            return DateTime.TryParse(value, out var result) ? result : default;
        }

        public static DateTime? ToNullableDateTime(this string value)
        {
            return !IsNullOrWhiteSpace((value ?? "").Trim()) ? value.ToDateTime() : null;
        }

        public static short ToInt16(this string value)
        {
            return short.TryParse(value, out var result) ? result : default;
        }

        public static short? ToNullableInt16(this string value)
        {
            return !IsNullOrWhiteSpace(value) ? value.ToInt16() : null;
        }

        public static int ToInt32(this string value)
        {
            return int.TryParse(value, out var result) ? result : default;
        }

        public static long ToInt64(this string value)
        {
            return long.TryParse(value, out var result) ? result : default;
        }

        public static byte ToByte(this string value)
        {
            return byte.TryParse(value, out var result) ? result : default;
        }

        public static byte? ToNullableByte(this string value)
        {
            return !IsNullOrWhiteSpace(value) ? value.ToByte() : null;
        }

        public static bool ToBoolean(this string value)
        {
            return bool.TryParse(value, out var result) && result;
        }

        public static float ToFloat(this string value)
        {
            return float.TryParse(value, out var result) ? result : default;
        }

        public static float? ToNullableFloat(this string value)
        {
            return !IsNullOrWhiteSpace(value) ? value.ToFloat() : null;
        }

        public static decimal ToDecimal(this string value)
        {
            return decimal.TryParse(value, out var result) ? result : default;
        }

        public static decimal? ToNullableDecimal(this string value)
        {
            return !IsNullOrWhiteSpace(value) ? value.ToDecimal() : null;
        }

        public static double ToDouble(this string value)
        {
            return double.TryParse(value, out var result) ? result : default;
        }

        public static double? ToNullableDouble(this string value)
        {
            return !IsNullOrWhiteSpace(value) ? value.ToDouble() : null;
        }

        public static Guid ToGuid(this string value)
        {
            return Guid.TryParse(value, out var result) ? result : default;
        }

        public static string ToBase64Encode(this string value)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(value));
        }

        public static string ToBase64Encode(this byte[] value)
        {
            return Convert.ToBase64String(value);
        }

        public static string ToBase64Decode(this string value)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(value));
        }

        public static byte[] ToByteFromBase64CharArray(this string value)
        {
            return Convert.FromBase64CharArray(value.ToCharArray(), 0, value.Length);
        }

        public static byte[] ToByteArray(this string value)
        {
            return Convert.FromBase64String(value);
        }

        public static string ToDateTimeFormat(this string date, string format)
        {
            return date.ToDateTime().ToString(format, CultureInfo.InvariantCulture);
        }

        public static string ToDateTimeFormat(this string date, string format, CultureInfo cultureInfo)
        {
            return date.ToDateTime().ToString(format, cultureInfo);
        }

        public static T ToEnum<T>(this string value, T defaultValue, bool ignoreCase = false)
            where T : struct
        {
            if (IsNullOrWhiteSpace(value)) return defaultValue;

            return Enum.TryParse<T>(value, ignoreCase, out var result) ? result : defaultValue;
        }

        public static string ToCamelCase(this string value)
        {
            if (!IsNullOrEmpty(value) && value.Length > 1) return char.ToLowerInvariant(value[0]) + value[1..];

            return value;
        }


        public static int GetYearsFromDate(this DateTime date)
        {
            var now = DateTime.UtcNow;
            var years = now.Year - date.Year;

            if (date.Month > now.Month || (date.Month == now.Month && date.Day > now.Day))
                years--;

            return years;
        }

        public static int GetYearsDifference(this DateTime date, DateTime dateToCompare)
        {
            var years = dateToCompare.Year - date.Year;

            if (date.Month > dateToCompare.Month || (date.Month == dateToCompare.Month && date.Day > dateToCompare.Day))
                years--;

            return years;
        }
    }

    public static class NullHandlingValidationExtension
    {
        public static IEnumerable<T> AsNotNull<T>(this IEnumerable<T> source)
        {
            return source ?? Enumerable.Empty<T>();
        }

        public static bool IsNotNull<T>(this IEnumerable<T> source)
        {
            return source is not null;
        }

        public static bool IsNotNull<T>(this T source)
        {
            return source is not null;
        }

        public static bool IsNull<T>(this IEnumerable<T> source)
        {
            return source is null;
        }

        public static bool IsNull<T>(this T source)
        {
            return source is null;
        }
    }

    public static class CollectionExtension
    {
        public static string GetValue(this NameValueCollection collection, string key, string def = null)
        {
            if (!collection.HasKey(key)) return def;
            var tmp = collection.Get(key);
            return !tmp.IsNullOrEmpty() ? tmp : def;
        }

        public static bool HasKey(this NameValueCollection queryString, string key)
        {
            if (queryString == null || key.IsNullOrEmpty() || !queryString.AllKeys.Contains(key)) return false;
            _ = queryString.Get(key) ?? throw new ArgumentNullException(nameof(queryString));

            return true;
        }

        public static bool IsGratherThanZero<T>(this IEnumerable<T> collection)
        {
            return collection.IsGratherThan(0);
        }

        public static bool IsGratherThan<T>(this IEnumerable<T> collection, int count)
        {
            if (collection == null) return false;

            return collection.Count() > count;
        }

        public static NameValueCollection ParseQueryString(this string queryString)
        {
            return !IsNullOrEmpty(queryString) ? HttpUtility.ParseQueryString(queryString) : new NameValueCollection();
        }

        public static string ToQueryString(this NameValueCollection collection)
        {
            if (collection is { Count: > 0 })
                return Join("&",
                    collection.AllKeys.Select(a =>
                        $"{HttpUtility.UrlEncode(a)}={HttpUtility.UrlEncode(collection[a])}"));

            return "";
        }

        public static TModel SingleOrNew<TModel>(this List<TModel> collection)
        {
            var obj = collection.SingleOrDefault();
            return obj ?? Activator.CreateInstance<TModel>();
        }

        public static TModel SingleOrNew<TModel>(this List<TModel> collection, Func<TModel, bool> predicate)
        {
            var obj = collection.SingleOrDefault(predicate);
            return obj ?? Activator.CreateInstance<TModel>();
        }

        public static TModel SingleOrNew<TModel>(this IEnumerable<TModel> collection, Func<TModel, bool> predicate)
        {
            var obj = collection.SingleOrDefault(predicate);
            return obj ?? Activator.CreateInstance<TModel>();
        }

        public static TModel FirstOrNew<TModel>(this List<TModel> collection)
        {
            var obj = collection.FirstOrDefault();
            return obj ?? Activator.CreateInstance<TModel>();
        }

        public static TModel FirstOrNew<TModel>(this IEnumerable<TModel> collection)
        {
            var obj = collection.FirstOrDefault();
            return obj ?? Activator.CreateInstance<TModel>();
        }

        public static TModel FirstOrNew<TModel>(this List<TModel> collection, Func<TModel, bool> predicate)
        {
            var obj = collection.FirstOrDefault(predicate);
            return obj ?? Activator.CreateInstance<TModel>();
        }

        public static TModel FirstOrNew<TModel>(this IEnumerable<TModel> collection, Func<TModel, bool> predicate)
        {
            var obj = collection.FirstOrDefault(predicate);
            return obj ?? Activator.CreateInstance<TModel>();
        }

        public static List<TModel> AddOnEmpty<TModel>(this List<TModel> collection)
        {
            if (collection.Count().Equals(0)) collection.Add(Activator.CreateInstance<TModel>());

            return collection;
        }

        public static void AddIfNotContains<T>(this IList<T> collection, T value)
        {
            if (value != null && !collection.Contains(value)) collection.Add(value);
        }

        public static void AddRangeIfNotContains<T>(this IList<T> collection, IEnumerable<T> values)
        {
            if (values == null) return;
            foreach (var value in values)
                collection.AddIfNotContains(value);
        }

        public static void AddIfTrueAndNotContains<T>(this IList<T> collection, T value, bool flag)
        {
            if (value != null && flag) collection.AddIfNotContains(value);
        }

        public static int IndexOf<T>(this IList<T> collection, Func<T, bool> predicate)
        {
            var index = 0;
            if (collection == null) return index;

            var item = collection.SingleOrDefault(predicate);
            if (item != null) index = collection.IndexOf(item);

            return index;
        }

        private static string GetProperty<T>(Expression<T> expression)
        {
            var body = expression.Body.ToString();
            body = body[(body.IndexOf('.') + 1)..].Remove("(").Remove(")");

            return body;
        }

        public static IList<T> AddIndexItem<T>(this IList<T> collection, Expression<Func<T, string>> expressionName,
            string valueName, int index)
        {
            return AddIndexItem(collection, expressionName, valueName, null, null, index);
        }

        public static IList<T> AddIndexItem<T>(this IList<T> collection, Expression<Func<T, string>> expressionName,
            string valueName, Expression<Func<T, int?>> expressionId, int? valueId, int index)
        {
            var instance = Activator.CreateInstance<T>();
            var type = instance.GetType();
            if (expressionName != null) type.GetProperty(GetProperty(expressionName))?.SetValue(instance, valueName);
            if (expressionId != null) type.GetProperty(GetProperty(expressionId))?.SetValue(instance, valueId);
            collection.Insert(index, instance);

            return collection;
        }

        public static IList<T> AddFirstItem<T>(this IList<T> collection, Expression<Func<T, string>> expressionName,
            string valueName, Expression<Func<T, int?>> expressionId, int? valueId)
        {
            return AddIndexItem(collection, expressionName, valueName, expressionId, valueId, 0);
        }

        public static IList<T> AddLastItem<T>(this IList<T> collection, Expression<Func<T, string>> expressionName,
            string valueName)
        {
            return AddLastItem(collection, expressionName, valueName, null, null);
        }

        public static IList<T> AddLastItem<T>(this IList<T> collection, Expression<Func<T, string>> expressionName,
            string valueName,
            Expression<Func<T, int?>> expressionId, int? valueId)
        {
            return AddIndexItem(collection, expressionName, valueName, expressionId, valueId, collection.Count);
        }
    }

    public static class StringExtension
    {
        public static string Remove(this string input, string strToRemove)
        {
            return input.IsNullOrEmpty() ? null : input.Replace(strToRemove, "");
        }

        public static string Left(this string input, int minusRight = 1)
        {
            if (input.IsNullOrEmpty() || input.Length <= minusRight) return null;

            return input[..^minusRight];
        }

        public static string GetHashAlgorithm(this string input)
        {
            HashAlgorithm hashAlgorithm = new SHA256CryptoServiceProvider();

            var byteValue = Encoding.UTF8.GetBytes(input);

            var byteHash = hashAlgorithm.ComputeHash(byteValue);

            return Convert.ToBase64String(byteHash);
        }

        public static CultureInfo ToCultureInfo(this string culture, CultureInfo defaultCulture)
        {
            return culture.IsNullOrEmpty() ? new CultureInfo(culture) : defaultCulture;
        }

        public static string ToCamelCasing(this string value)
        {
            if (!IsNullOrEmpty(value)) return value[..1].ToUpper() + value[1..^1];

            return value;
        }

        public static double? ToDouble(this string value, string culture = "en-US")
        {
            try
            {
                return double.Parse(value, new CultureInfo(culture));
            }
            catch
            {
                return null;
            }
        }

        public static bool? ToBoolean(this string value)
        {
            if (bool.TryParse(value, out var valor)) return valor;

            return null;
        }

        public static int? ToInt32(this string value)
        {
            if (int.TryParse(value, out var valor)) return valor;

            return null;
        }

        public static long? ToInt64(this string value)
        {
            if (long.TryParse(value, out var valor)) return valor;

            return null;
        }

        public static Guid? ToGuid(this string value)
        {
            if (Guid.TryParse(value, out var valor)) return valor;

            return null;
        }

        public static Guid ToGuid(this string value, Guid defaultValue)
        {
            return Guid.TryParse(value, out var valor) ? valor : defaultValue;
        }

        public static string AddQueyString(this string url, string queryStringKey, string queryStringValue)
        {
            var segments = url.Split('?');
            var queryString = segments.Length > 1 ? "&" : "?";

            return url + queryString + queryStringKey + "=" + queryStringValue;
        }

        public static string FormatFirstLetterUpperCase(this string value, string culture = "en-US")
        {
            return CultureInfo.GetCultureInfo(culture).TextInfo.ToTitleCase(value);
        }

        public static string FillLeftWithZeros(this string value, int decimalDigits)
        {
            if (IsNullOrEmpty(value)) return value;
            var sb = new StringBuilder();
            sb.Append(value);
            var s = value.Split(',');
            for (var i = s[^1].Length; i < decimalDigits; i++) sb.Append("0");

            value = sb.ToString();

            return value;
        }

        public static string FormatWithDecimalDigits(this string value,
            int? decimalDigits)
        {
            if (value.IsNullOrEmpty()) return value;

            if (value.IndexOf(",", StringComparison.Ordinal).Equals(-1))
                return decimalDigits.HasValue ? value.FillLeftWithZeros(decimalDigits.Value) : value;
            var s = value.Split(',');
            if (s.Length.Equals(2) && s[1].Length > 0)
                value = s[0] + "," +
                        s[1][
                            ..(decimalDigits != null && s[1].Length >= decimalDigits.Value
                                ? decimalDigits.Value
                                : s[1].Length)];

            return decimalDigits.HasValue ? value.FillLeftWithZeros(decimalDigits.Value) : value;
        }

        public static string FormatWithoutDecimalDigits(this string value, bool removeCurrencySymbol,
            CultureInfo culture)
        {
            if (removeCurrencySymbol) value = value.Remove(culture.NumberFormat.CurrencySymbol).Trim();

            return value;
        }
    }

    public static class JsonExtensions
    {
        public static string ToJson<T>(this T obj)
        {
            return obj != null ? JsonConvert.SerializeObject(obj) : null;
        }

        public static T FromJson<T>(this string json)
        {
            if (IsNullOrEmpty(json)) return default;

            return (T)JsonConvert.DeserializeObject(json);
        }

        public static T FromXml<T>(this string xml)
        {
            if (IsNullOrEmpty(xml)) return default;

            var xmlSer = new XmlSerializer(typeof(T));
            using var str = new StringReader(xml);
            var result = (T)xmlSer.Deserialize(str);

            return result;
        }

        public static string ToXml<T>(this T obj)
        {
            if (obj == null) return null;

            var xmlSer = new XmlSerializer(obj.GetType());
            using var m = new MemoryStream();
            xmlSer.Serialize(m, obj);
            var result = Encoding.UTF8.GetString(m.GetBuffer()).Replace("\0", "");

            return result;
        }

        public static T JsonToObject<T>(this string json)
        {
            var settings = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        public static IDictionary<string, object> JsonToDictionary(this string val)
        {
            if (IsNullOrEmpty(val)) throw new ArgumentNullException(nameof(val));
            return
                (Dictionary<string, object>)JsonConvert.DeserializeObject(val, typeof(Dictionary<string, object>));
        }
    }

    public static class IsNullExtension
    {
        public static bool IsNotNull<T>(this T data)
        {
            return data != null;
        }

        public static string IsNull(this string value, string defaultValue)
        {
            return !IsNullOrEmpty(value) ? value : defaultValue;
        }

        public static string IsNotNullConcatRight(this string str, params string[] concat)
        {
            if (str.IsNullOrEmpty()) return str;

            var list = concat.ToList();
            list.Add(str);

            return Concat(list.ToArray());
        }

        public static string IsNotNullConcatLeft(this string str, params string[] concat)
        {
            if (str.IsNullOrEmpty()) return str;

            var list = concat.ToList();
            list.Insert(0, str);

            return Concat(list.ToArray());
        }

        public static bool IsNull(this bool? value, bool def)
        {
            return value ?? def;
        }

        public static T IsNull<T>(this T value)
            where T : class
        {
            return value ?? Activator.CreateInstance<T>();
        }

        public static T IsNull<T>(this T value, T def)
            where T : class
        {
            if (value != null) return value;

            return def ?? Activator.CreateInstance<T>();
        }

        public static int IsNull(this int? value, int def)
        {
            return value ?? def;
        }

        public static long IsNull(this long? value, long def)
        {
            return value ?? def;
        }

        public static double IsNull(this double? value, double def)
        {
            return value ?? def;
        }

        public static DateTime IsNull(this DateTime? value, DateTime def)
        {
            return value ?? def;
        }

        public static Guid IsNull(this Guid? value, Guid def)
        {
            return value ?? def;
        }
    }

    public static class QueryStringExtension
    {
        public static string GetSecureQueryString(string qs)
        {
            var newQs = "";
            if (IsNullOrEmpty(qs)) return newQs;
            newQs = HttpUtility.UrlDecode(qs);
            if (Regex.Match(newQs, "[<';>]").Success) newQs = "";

            return newQs;
        }

        public static string GetSecure(this NameValueCollection obj, string name)
        {
            return GetSecureQueryString(obj[name]);
        }

        public static string ToString(this NameValueCollection obj, bool secure)
        {
            return secure ? GetSecureQueryString(obj.ToString()) : obj.ToString();
        }
    }

    public static class EnumExtensions
    {
        public static IEnumerable<Enum> ToEnumerable(this Enum input)
        {
            return Enum.GetValues(input.GetType()).Cast<Enum>()
                .Where(value => input.HasFlag(value) && Convert.ToInt64(value) != 0);
        }

        public static int ToInt32(this Enum input)
        {
            return (from Enum value in Enum.GetValues(input.GetType())
                    where value.Equals(input)
                    select Convert.ToInt32(value)).FirstOrDefault();
        }

        public static T ToEnum<T>(this string input)
        {
            if (!IsNullOrEmpty(input)) return (T)Enum.Parse(typeof(T), input);
            return default;
        }

        public static IEnumerable<T> EnumToList<T>()
        {
            var enumType = typeof(T);
            if (enumType.BaseType != typeof(Enum))
                throw new ArgumentException("T must be of type System.Enum");

            var enumValArray = Enum.GetValues(enumType);
            var enumValList = new List<T>(enumValArray.Length);
            enumValList.AddRange(from int val in enumValArray select (T)Enum.Parse(enumType, val.ToString()));
            return enumValList.AsEnumerable();
        }

        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ? (T)attributes[0] : null;
        }

        public static string ToDescription(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static string ToHumanCase(this Enum e)
        {
            var upperCamelCaseRegex =
                new Regex(@"(?<!^)((?<!\d)\d|(?(?<=[A-Z])[A-Z](?=[a-z])|[A-Z]))", RegexOptions.Compiled);
            return upperCamelCaseRegex.Replace(e.ToString(), " $1");
        }
    }

    public static class Community
    {
        public static readonly int PassMax = -1;
        public static readonly double Min = 0.0000001;

        public static double Modularity(Graph graph, Dictionary<int, int> partition)
        {
            var inc = new Dictionary<int, double>();
            var deg = new Dictionary<int, double>();

            var links = graph.Size;
            if (links == 0) throw new InvalidOperationException("A graph without links has undefined modularity.");

            foreach (var node in graph.Nodes)
            {
                var com = partition[node];
                deg[com] = DictGet(deg, com, 0) + graph.Degree(node);
                foreach (var edge in graph.IncidentEdges(node))
                {
                    var neighbor = edge.ToNode;
                    if (partition[neighbor] != com) continue;
                    double weight;
                    if (neighbor == node)
                        weight = edge.Weight;
                    else
                        weight = edge.Weight / 2;
                    inc[com] = DictGet(inc, com, 0) + weight;
                }
            }

            return partition.Values.Distinct().Sum(component =>
                DictGet(inc, component, 0) / links - Math.Pow(DictGet(deg, component, 0) / (2 * links), 2));
        }

        public static Dictionary<int, int> BestPartition(Graph graph, Dictionary<int, int> partition)
        {
            var dendrogram = GenerateDendrogram(graph, partition);
            return dendrogram.PartitionAtLevel(dendrogram.Length - 1);
        }

        public static Dictionary<int, int> BestPartition(Graph graph)
        {
            return BestPartition(graph, null);
        }

        public static Dendrogram GenerateDendrogram(Graph graph, Dictionary<int, int> partInit)
        {
            Dictionary<int, int> partition;
            var stopwatch = new Stopwatch();
            stopwatch.Restart();

            if (graph.NumberOfEdges == 0)
            {
                partition = new Dictionary<int, int>();
                var i = 0;
                foreach (var node in graph.Nodes) partition[node] = i++;
                return new Dendrogram(partition);
            }

            var currentGraph = new Graph(graph);
            var status = new Status(currentGraph, partInit);
            double mod;
            var statusList = new List<Dictionary<int, int>>();
            status.OneLevel(currentGraph);
            var newMod = status.Modularity();

            do
            {
                partition = Renumber(status.Node2Com);
                statusList.Add(partition);
                mod = newMod;
                currentGraph = currentGraph.Quotient(partition);
                status = new Status(currentGraph, null);
                status.OneLevel(currentGraph);
                newMod = status.Modularity();
            } while (newMod - mod >= Min);

            return new Dendrogram(statusList);
        }

        private static Dictionary<TA, int> Renumber<TA>(Dictionary<TA, int> dict)
        {
            var ret = new Dictionary<TA, int>();
            var newValues = new Dictionary<int, int>();

            foreach (var key in dict.Keys.OrderBy(a => a))
            {
                var value = dict[key];
                if (!newValues.TryGetValue(value, out var newValue)) newValue = newValues[value] = newValues.Count;
                ret[key] = newValue;
            }

            return ret;
        }

        private static TB DictGet<TA, TB>(IReadOnlyDictionary<TA, TB> dict, TA key, TB defaultValue)
        {
            return dict.TryGetValue(key, out var result) ? result : defaultValue;
        }

        public class Status
        {
            public readonly Dictionary<int, double> Degrees;
            public readonly Dictionary<int, double> GDegrees;
            public readonly Dictionary<int, double> Internals;
            public readonly Dictionary<int, double> Loops;
            public readonly Dictionary<int, int> Node2Com;
            public readonly double TotalWeight;

            public Status()
            {
                Node2Com = new Dictionary<int, int>();
                TotalWeight = 0;
                Degrees = new Dictionary<int, double>();
                GDegrees = new Dictionary<int, double>();
                Loops = new Dictionary<int, double>();
                Internals = new Dictionary<int, double>();
            }

            public Status(Graph graph, IReadOnlyDictionary<int, int> part)
                : this()
            {
                var count = 0;
                TotalWeight = graph.Size;
                if (part == null)
                    foreach (var node in graph.Nodes)
                    {
                        Node2Com[node] = count;
                        var deg = graph.Degree(node);
                        if (deg < 0) throw new ArgumentException("Graph has negative weights.");
                        Degrees[count] = GDegrees[node] = deg;
                        Internals[count] = Loops[node] = graph.EdgeWeight(node, node, 0);
                        count += 1;
                    }
                else
                    foreach (var node in graph.Nodes)
                    {
                        var com = part[node];
                        Node2Com[node] = com;
                        var deg = graph.Degree(node);
                        Degrees[com] = DictGet(Degrees, com, 0) + deg;
                        GDegrees[node] = deg;
                        double inc = 0;
                        foreach (var edge in graph.IncidentEdges(node))
                        {
                            var neighbor = edge.ToNode;
                            if (edge.Weight <= 0) throw new ArgumentException("Graph must have postive weights.");
                            if (part[neighbor] != com) continue;
                            if (neighbor == node)
                                inc += edge.Weight;
                            else
                                inc += edge.Weight / 2;
                        }

                        Internals[com] = DictGet(Internals, com, 0) + inc;
                    }
            }

            public double Modularity()
            {
                return (from community in Node2Com.Values.Distinct()
                        let inDegree = DictGet(Internals, community, 0)
                        let degree = DictGet(Degrees, community, 0)
                        where TotalWeight > 0
                        select inDegree / TotalWeight - Math.Pow(degree / (2 * TotalWeight), 2)).Sum();
            }

            public Tuple<double, int> EvaluateIncrease(int com, double dnc, double degcTotw)
            {
                var incr = dnc - DictGet(Degrees, com, 0) * degcTotw;
                return Tuple.Create(incr, com);
            }

            public void OneLevel(Graph graph)
            {
                var modify = true;
                var nbPassDone = 0;
                var curMod = Modularity();
                var newMod = curMod;

                while (modify && nbPassDone != PassMax)
                {
                    curMod = newMod;
                    modify = false;
                    nbPassDone += 1;

                    foreach (var node in graph.Nodes)
                    {
                        var comNode = Node2Com[node];
                        var degTote = DictGet(GDegrees, node, 0) / (TotalWeight * 2);
                        var neighCommunities = NeighCom(node, graph);
                        Remove(node, comNode, DictGet(neighCommunities, comNode, 0));

                        var best = (from entry in neighCommunities.AsParallel()
                                    select EvaluateIncrease(entry.Key, entry.Value, degTote))
                            .Concat(new[] { Tuple.Create(0.0, comNode) }.AsParallel())
                            .Max();
                        var bestCom = best.Item2;
                        Insert(node, bestCom, DictGet(neighCommunities, bestCom, 0));
                        if (bestCom != comNode) modify = true;
                    }

                    newMod = Modularity();
                    if (newMod - curMod < Min) break;
                }
            }

            public Dictionary<int, double> NeighCom(int node, Graph graph)
            {
                var weights = new Dictionary<int, double>();
                foreach (var edge in graph.IncidentEdges(node))
                    if (!edge.SelfLoop)
                    {
                        var neighbor = Node2Com[edge.ToNode];
                        weights[neighbor] = DictGet(weights, neighbor, 0) + edge.Weight;
                    }

                return weights;
            }

            public void Remove(int node, int com, double weight)
            {
                Degrees[com] = DictGet(Degrees, com, 0) - DictGet(GDegrees, node, 0);
                Internals[com] = DictGet(Internals, com, 0) - weight - DictGet(Loops, node, 0);
                Node2Com[node] = -1;
            }

            public void Insert(int node, int com, double weight)
            {
                Node2Com[node] = com;
                Degrees[com] = DictGet(Degrees, com, 0) + DictGet(GDegrees, node, 0);
                Internals[com] = DictGet(Internals, com, 0) + weight + DictGet(Loops, node, 0);
            }
        }
    }

    public class Dendrogram
    {
        private readonly List<Dictionary<int, int>> _partitions;

        public Dendrogram(Dictionary<int, int> part)
        {
            _partitions = new List<Dictionary<int, int>> { part };
        }

        public Dendrogram(IEnumerable<Dictionary<int, int>> parts)
        {
            _partitions = new List<Dictionary<int, int>>(parts);
        }

        public int Length => _partitions.Count;

        public Dictionary<int, int> PartitionAtLevel(int level)
        {
            var partition = new Dictionary<int, int>(_partitions[0]);
            for (var index = 1; index <= level; index++)
                foreach (var node in partition.Keys.ToArray())
                {
                    var com = partition[node];
                    partition[node] = _partitions[index][com];
                }

            return partition;
        }
    }

    public class Graph
    {
        private readonly Dictionary<int, Dictionary<int, double>> _adjacencyMatrix;

        public Graph()
        {
            _adjacencyMatrix = new Dictionary<int, Dictionary<int, double>>();
        }

        public Graph(Graph g)
        {
            _adjacencyMatrix = new Dictionary<int, Dictionary<int, double>>();
            foreach (var ilist in g._adjacencyMatrix)
                _adjacencyMatrix[ilist.Key] = new Dictionary<int, double>(ilist.Value);
            NumberOfEdges = g.NumberOfEdges;
            Size = g.Size;
        }

        public int NumberOfEdges { get; private set; }

        public double Size { get; private set; }

        public IEnumerable<int> Nodes => _adjacencyMatrix.Keys;

        public IEnumerable<Edge> Edges => from entry1 in _adjacencyMatrix
                                          from entry2 in entry1.Value
                                          where entry1.Key <= entry2.Key
                                          select new Edge(entry1.Key, entry2.Key, entry2.Value);

        public void AddNode(int node)
        {
            EnsureIncidenceList(node);
        }

        public void AddEdge(int node1, int node2, double weight)
        {
            AddDirectedEdge(node1, node2, weight);
            if (node1 != node2) AddDirectedEdge(node2, node1, weight);
            NumberOfEdges += 1;
            Size += weight;
        }

        private void AddDirectedEdge(int node1, int node2, double weight)
        {
            var ilist = EnsureIncidenceList(node1);
            ilist.TryGetValue(node2, out var oldWeight);
            ilist[node2] = oldWeight + weight;
        }

        public void SetEdge(int node1, int node2, double weight)
        {
            SetDirectedEdge(node1, node2, weight);
            if (node1 != node2) SetDirectedEdge(node2, node1, weight);
            NumberOfEdges += 1;
            Size += weight;
        }

        private void SetDirectedEdge(int node1, int node2, double weight)
        {
            var ilist = EnsureIncidenceList(node1);
            ilist[node2] = weight;
        }

        private Dictionary<int, double> EnsureIncidenceList(int node)
        {
            if (!_adjacencyMatrix.TryGetValue(node, out var ilist))
                ilist = _adjacencyMatrix[node] = new Dictionary<int, double>();
            return ilist;
        }

        public double Degree(int node)
        {
            _adjacencyMatrix[node].TryGetValue(node, out var loop);
            return _adjacencyMatrix[node].Values.Sum() + loop;
        }

        public IEnumerable<Edge> IncidentEdges(int node)
        {
            if (!_adjacencyMatrix.TryGetValue(node, out var incidence)) yield break;
            foreach (var entry in incidence)
                yield return new Edge(node, entry.Key, entry.Value);
        }

        public double EdgeWeight(int node1, int node2, double defaultValue)
        {
            if (!_adjacencyMatrix.TryGetValue(node1, out var ilist))
                throw new IndexOutOfRangeException("No such node " + node1);
            return !ilist.TryGetValue(node2, out var value) ? defaultValue : value;
        }

        public Graph Quotient(Dictionary<int, int> partition)
        {
            var ret = new Graph();
            foreach (var com in partition.Values) ret.AddNode(com);
            foreach (var edge in Edges) ret.AddEdge(partition[edge.FromNode], partition[edge.ToNode], edge.Weight);
            return ret;
        }

        public Graph RandomizedNodes(Random random)
        {
            var g = new Graph();
            var nodes = Nodes.ToList();
            for (var i = nodes.Count - 1; i >= 1; i--)
            {
                var j = random.Next(i + 1);
                (nodes[i], nodes[j]) = (nodes[j], nodes[i]);
            }

            var remapping = new Dictionary<int, int>();
            for (var i = 0; i < nodes.Count; i++) remapping[nodes[i]] = i;
            var edges = Edges.ToList();
            for (var i = edges.Count - 1; i >= 1; i--)
            {
                var j = random.Next(i + 1);
                (edges[i], edges[j]) = (edges[j], edges[i]);
            }

            foreach (var edge in edges) g.AddEdge(remapping[edge.FromNode], remapping[edge.ToNode], edge.Weight);
            return g;
        }

        public struct Edge
        {
            public int FromNode;
            public int ToNode;
            public double Weight;

            public Edge(int n1, int n2, double w)
            {
                FromNode = n1;
                ToNode = n2;
                Weight = w;
            }

            public bool SelfLoop => FromNode == ToNode;
        }
    }

    public static class Laplace
    {
        public static double Location { get; set; }

        public static double Scale { get; set; }

        public static double Mean => Location;

        public static double Variance => 2.0 * Scale * Scale;

        public static double Skewness => 0.0;

        public static double Mode => Location;

        public static double Median => Location;

        public static double Minimum => double.NegativeInfinity;

        public static double Maximum => double.PositiveInfinity;

        public static bool IsValidParameterSet(double location, double scale)
        {
            return scale > 0.0 && !double.IsNaN(location);
        }

        public static double Density(double x)
        {
            return Math.Exp(-Math.Abs(x - Location) / Scale) / (2.0 * Scale);
        }

        public static double DensityLn(double x)
        {
            return -Math.Abs(x - Location) / Scale - Math.Log(2.0 * Scale);
        }

        public static double CumulativeDistribution(double x)
        {
            return 0.5 * (1.0 + Math.Sign(x - Location) * (1.0 - Math.Exp(-Math.Abs(x - Location) / Scale)));
        }
    }

    public static class ConwayMaxwellPoisson
    {
        private const double Tolerance = 1e-12;
        public static readonly double Nude = 0;
        private static double _mean = double.MinValue;
        private static double _variance = double.MinValue;
        private static double _z = double.MinValue;
        public static double Lambda { get; set; }

        public static double Nu
        {
            get => Nude;
            set => throw new NotImplementedException();
        }

        public static double Mean
        {
            get
            {
                if (Lambda == 0) return 0.0;
                if (_mean.CompareTo(double.MinValue) != 0) return _mean;
                var z = 1 + Lambda;
                var a1 = Lambda * Lambda / Math.Pow(2, Nude);
                var zx = Lambda;
                var ax1 = 2 * a1;
                for (var i = 3; i < 1000; i++)
                {
                    var e = Lambda / Math.Pow(i, Nude);
                    var ex = Lambda / Math.Pow(i, Nude - 1) / (i - 1);
                    var a2 = a1 * e;
                    var ax2 = ax1 * ex;
                    var m = zx / z;
                    var upper = (zx + ax1 / (1 - ax2 / ax1)) / z;
                    var lower = zx / (z + a1 / (1 - a2 / a1));
                    if (ax2 < ax1 && a2 < a1)
                    {
                        var r = (upper - lower) / m;
                        if (r < Tolerance) break;
                    }

                    z += a1;
                    zx += ax1;
                    a1 = a2;
                    ax1 = ax2;
                }

                _mean = zx / z;
                return _mean;
            }
        }

        public static double Variance
        {
            get
            {
                if (Lambda == 0) return 0.0;
                if (_variance.CompareTo(double.MinValue) != 0) return _variance;
                var z = 1 + Lambda;
                var a1 = Lambda * Lambda / Math.Pow(2, Nude);
                var zxx = Lambda;
                var axx1 = 4 * a1;
                for (var i = 3; i < 1000; i++)
                {
                    var e = Lambda / Math.Pow(i, Nude);
                    var exx = Lambda / Math.Pow(i, Nude - 2) / (i - 1) / (i - 1);
                    var a2 = a1 * e;
                    var axx2 = axx1 * exx;
                    var m = zxx / z;
                    var upper = (zxx + axx1 / (1 - axx2 / axx1)) / z;
                    var lower = zxx / (z + a1 / (1 - a2 / a1));
                    if (axx2 < axx1 && a2 < a1)
                    {
                        var r = (upper - lower) / m;
                        if (r < Tolerance) break;
                    }

                    z += a1;
                    zxx += axx1;
                    a1 = a2;
                    axx1 = axx2;
                }

                var mean = Mean;
                _variance = zxx / z - mean * mean;
                return _variance;
            }
        }

        public static double StdDev => Math.Sqrt(Variance);

        public static double Entropy => throw new NotSupportedException();

        public static double Skewness => throw new NotSupportedException();

        public static int Mode => throw new NotSupportedException();

        public static double Median => throw new NotSupportedException();

        public static int Minimum => 0;

        public static int Maximum => throw new NotSupportedException();

        public static double Z
        {
            get
            {
                if (_z.CompareTo(double.MinValue) != 0) return _z;
                _z = Normalization(Lambda, Nude);
                return _z;
            }
        }

        public static bool IsValidParameterSet(double lambda, double nu)
        {
            return lambda > 0.0 && nu >= 0.0;
        }

        public static double Normalization(double lambda, double nu)
        {
            var z = 1.0 + lambda;
            var t = lambda;
            for (var i = 2; i < 1000; i++)
            {
                var e = lambda / Math.Pow(i, nu);
                t *= e;
                z += t;
                if (!(e < 1)) continue;
                if (t / (1 - e) / z < Tolerance) break;
            }

            return z;
        }
    }

    public static class Dirichlet
    {
        public static double[] Alpha { get; set; }

        public static int Dimension => Alpha.Length;

        private static double AlphaSum => Alpha.Sum();

        public static double[] Mean
        {
            get
            {
                var sum = AlphaSum;
                var parm = new double[Dimension];
                for (var i = 0; i < Dimension; i++) parm[i] = Alpha[i] / sum;
                return parm;
            }
        }

        public static double[] Variance
        {
            get
            {
                var s = AlphaSum;
                var v = new double[Alpha.Length];
                for (var i = 0; i < Alpha.Length; i++) v[i] = Alpha[i] * (s - Alpha[i]) / (s * s * (s + 1.0));
                return v;
            }
        }

        public static bool IsValidParameterSet(double[] alpha)
        {
            var allZero = true;
            foreach (var t in alpha)
                switch (t)
                {
                    case < 0.0:
                        return false;
                    case > 0.0:
                        allZero = false;
                        break;
                }

            return !allZero;
        }
    }

    public static class Erlang
    {
        public static int Shape { get; set; }

        public static double Rate { get; set; }

        public static double Scale => 1.0 / Rate;

        public static double Mean
        {
            get
            {
                if (double.IsPositiveInfinity(Rate)) return Shape;

                if (Rate == 0.0 && Shape == 0.0) return double.NaN;

                return Shape / Rate;
            }
        }

        public static double Variance
        {
            get
            {
                if (double.IsPositiveInfinity(Rate)) return 0.0;

                if (Rate == 0.0 && Shape == 0.0) return double.NaN;

                return Shape / (Rate * Rate);
            }
        }

        public static double StdDev
        {
            get
            {
                if (double.IsPositiveInfinity(Rate)) return 0.0;

                if (Rate == 0.0 && Shape == 0.0) return double.NaN;

                return Math.Sqrt(Shape) / Rate;
            }
        }

        public static double Skewness
        {
            get
            {
                if (double.IsPositiveInfinity(Rate)) return 0.0;

                if (Rate == 0.0 && Shape == 0.0) return double.NaN;

                return 2.0 / Math.Sqrt(Shape);
            }
        }

        public static double Mode
        {
            get
            {
                if (Shape < 1) throw new NotSupportedException();

                if (double.IsPositiveInfinity(Rate)) return Shape;

                if (Rate == 0.0 && Shape == 0.0) return double.NaN;

                return (Shape - 1.0) / Rate;
            }
        }

        public static double Median => throw new NotSupportedException();

        public static double Minimum => 0.0;

        public static double Maximum => double.PositiveInfinity;

        public static bool IsValidParameterSet(int shape, double rate)
        {
            return shape >= 0 && rate >= 0.0;
        }

        public static bool IsValidParameterSet(double shape, double rate)
        {
            return IsValidParameterSet((int)shape, rate);
        }
    }

    public static class Gamma
    {
        public static double Shape { get; set; }

        public static double Rate { get; set; }

        public static double Scale => 1.0 / Rate;

        public static double Mean
        {
            get
            {
                if (double.IsPositiveInfinity(Rate)) return Shape;

                if (Rate == 0.0 && Shape == 0.0) return double.NaN;

                return Shape / Rate;
            }
        }

        public static double Variance
        {
            get
            {
                if (double.IsPositiveInfinity(Rate)) return 0.0;

                if (Rate == 0.0 && Shape == 0.0) return double.NaN;

                return Shape / (Rate * Rate);
            }
        }

        public static double StdDev
        {
            get
            {
                if (double.IsPositiveInfinity(Rate)) return 0.0;

                if (Rate == 0.0 && Shape == 0.0) return double.NaN;

                return Math.Sqrt(Shape / (Rate * Rate));
            }
        }

        public static double Skewness
        {
            get
            {
                if (double.IsPositiveInfinity(Rate)) return 0.0;

                if (Rate == 0.0 && Shape == 0.0) return double.NaN;

                return 2.0 / Math.Sqrt(Shape);
            }
        }

        public static double Mode
        {
            get
            {
                if (double.IsPositiveInfinity(Rate)) return Shape;

                if (Rate == 0.0 && Shape == 0.0) return double.NaN;

                return (Shape - 1.0) / Rate;
            }
        }

        public static double Median => throw new NotSupportedException();

        public static double Minimum => 0.0;

        public static double Maximum => double.PositiveInfinity;

        public static bool IsValidParameterSet(double shape, double rate)
        {
            return shape >= 0.0 && rate >= 0.0;
        }
    }

    public static class Sequence
    {
        public static bool IsMonotonic(this double[] sequence)
        {
            if (sequence == null || sequence.Length < 2)
                return false;

            if (sequence.Where(double.IsNaN).Any())
                return false;

            var sign = 0;
            var counter = 0;

            while (sign == 0 && counter < sequence.Length - 1)
                sign = Math.Sign(sequence[counter + 1] - sequence[counter++]);

            if (sign == 0)
                return true;

            for (var i = counter; i < sequence.Length - 1; i++)
            {
                var localSign = Math.Sign(sequence[i + 1] - sequence[i]);

                if (localSign != sign && localSign != 0)
                    return false;
            }

            return true;
        }

        public static bool IsMonotonicIncreasing(this double[] sequence)
        {
            return sequence.IsMonotonic() && sequence.Last() >= sequence.First();
        }

        public static bool IsMonotonicDecreasing(this double[] sequence)
        {
            return sequence.IsMonotonic() && sequence.Last() <= sequence.First();
        }

        public static bool IsMonotonic(this int[] sequence)
        {
            if (sequence == null || sequence.Length == 0)
                return false;

            return sequence.Select(i => (double)i).ToArray().IsMonotonic();
        }

        public static bool IsMonotonicIncreasing(this int[] sequence)
        {
            return sequence.IsMonotonic() && sequence.Last() >= sequence.First();
        }

        public static bool IsMonotonicDecreasing(this int[] sequence)
        {
            return sequence.IsMonotonic() && sequence.Last() <= sequence.First();
        }

        public static bool IsStrictlyMonotonic(this double[] sequence)
        {
            if (sequence == null || sequence.Length < 2)
                return false;

            if (sequence.Where(double.IsNaN).Any())
                return false;

            var sign = Math.Sign(sequence[1] - sequence[0]);

            if (sign == 0)
                return false;

            for (var i = 1; i < sequence.Length - 1; i++)
            {
                var localSign = Math.Sign(sequence[i + 1] - sequence[i]);

                if (localSign != sign)
                    return false;
            }

            return true;
        }

        public static bool IsStrictlyMonotonicIncreasing(this double[] sequence)
        {
            return sequence.IsStrictlyMonotonic() && sequence.Last() > sequence.First();
        }

        public static bool IsStrictlyMonotonicDecreasing(this double[] sequence)
        {
            return sequence.IsStrictlyMonotonic() && sequence.Last() < sequence.First();
        }

        public static bool IsStrictlyMonotonic(this int[] sequence)
        {
            if (sequence == null || sequence.Length == 0)
                return false;

            return sequence.Select(i => (double)i).ToArray().IsStrictlyMonotonic();
        }

        public static bool IsStrictlyMonotonicIncreasing(this int[] sequence)
        {
            return sequence.IsStrictlyMonotonic() && sequence.Last() > sequence.First();
        }

        public static bool IsStrictlyMonotonicDecreasing(this int[] sequence)
        {
            return sequence.IsStrictlyMonotonic() && sequence.Last() < sequence.First();
        }
    }

    #endregion

    #region Interface

    public interface IUnivariateDistribution : IDistribution
    {
        double Mean { get; }
        double Variance { get; }
        double StdDev { get; }
        double Entropy { get; }
        double Skewness { get; }
        double Median { get; }
        double CumulativeDistribution(double x);
    }

    public interface IContinuousDistribution : IUnivariateDistribution
    {
        double Mode { get; }
        double Minimum { get; }
        double Maximum { get; }
        double Density(double x);
        double DensityLn(double x);
        double Sample();
        void Samples(double[] values);
        IEnumerable<double> Samples();
    }

    public interface IDistribution
    {
        Random RandomSource => MathV.RandomV;
    }

    #endregion

    #endregion

    #region Math

    /// <summary>
    ///     数学函数库C
    /// </summary>
    public static class MathC
    {
        public const ulong Multiplier = 6364136223846793005ul;
        public const uint PcgMultiplier = 747796405u;
        public const uint PcgIncrement = 2891336453u;
        public const uint McgMultiplier = 277803737u;
        public const uint McgUnmultiplier = 2897767785u;
        public static float Eps;
        public static double Deps;
        public static readonly int TablePow2 = 10;
        public static ulong Increment = 1442695040888963407ul;

        /// <summary>
        ///     返回机器特定估计浮点值
        /// </summary>
        public static float MEps => Eps;

        /// <summary>
        ///     返回机器特定估计双精度值
        /// </summary>
        public static double MDeps => Deps;

        public static int Equidistribution()
        {
            return 1 << TablePow2;
        }

        public static int EquidistributionPow2()
        {
            return TablePow2;
        }

        public static int PeriodPow2()
        {
            return (1 << TablePow2) * 32 + 64;
        }

        public static void SetStream(int sequence)
        {
            SetStream((ulong)sequence);
        }

        public static void SetStream(ulong sequence)
        {
            Increment = (sequence << 1) | 1;
        }

        public static ulong CurrentStream()
        {
            return Increment >> 1;
        }

        public static ulong Bump(ulong state)
        {
            return state * Multiplier + Increment;
        }

        public static bool ExternalStep(ref uint randval, int i)
        {
            var state = UnOutput(randval);
            state = unchecked(state * PcgMultiplier + PcgIncrement + (uint)i * 2u);
            var rshift = (int)(state >> 28) + 4;
            state ^= state >> rshift;
            state *= McgMultiplier;
            var result = state ^ (state >> 22);
            randval = result;
            return result == 0u;
        }

        public static uint UnOutput(uint @internal)
        {
            @internal ^= @internal >> 22;
            @internal *= McgUnmultiplier;
            var rshift = (int)(@internal >> 28);
            @internal = UnXorShift(@internal, 32, 4 + rshift);
            return @internal;
        }

        public static uint UnXorShift(uint x, int bits, int shift)
        {
            if (2 * shift >= bits)
                return x ^ (x >> shift);
            var lowmask1 = (1u << (bits - 2 * shift)) - 1u;
            var highmask1 = ~lowmask1;
            var top1 = x;
            var bottom1 = x & lowmask1;
            top1 ^= top1 >> shift;
            top1 &= highmask1;
            x = top1 | bottom1;
            var lowmask2 = (1u << (bits - shift)) - 1u;
            var bottom2 = x & lowmask2;
            bottom2 = UnXorShift(bottom2, bits - shift, shift);
            bottom2 &= lowmask1;
            return top1 | bottom2;
        }

        /// <summary>
        ///     钳制在0f-1f
        /// </summary>
        public static float Clamp01(this float value)
        {
            if (value < (double)0.0f)
                return 0.0f;
            return value > (double)1.0f ? 1.0f : value;
        }

        /// <summary>
        ///     更新单精度eps估计值
        /// </summary>
        public static void UpdateEps(float centre = 1.0f)
        {
            EstimateEps(centre);
        }

        /// <summary>
        ///     更新双精度eps估计值
        /// </summary>
        public static void UpdateDeps(double centre = 1.0)
        {
            EstimateDeps(centre);
        }

        /// <summary>
        ///     判断浮点数a==b
        /// </summary>
        public static bool AeqB(float a, float b)
        {
            return MathV.Abs(a - b) < MEps;
        }

        /// <summary>
        ///     判断双浮点数a==b
        /// </summary>
        public static bool AeqB(double a, double b)
        {
            return MathV.Abs(a - b) < MDeps;
        }

        /// <summary>
        ///     判断双精度a!=b
        /// </summary>
        public static bool AneqB(float a, float b)
        {
            return MathV.Abs(a - b) > MEps;
        }

        /// <summary>
        ///     判断双精度a!=b
        /// </summary>
        public static bool AneqB(double a, double b)
        {
            return MathV.Abs(a - b) > MDeps;
        }

        /// <summary>
        ///     判断浮点数a==0
        /// </summary>
        public static bool AeqZero(float a)
        {
            return MathV.Abs(a) < MEps;
        }

        /// <summary>
        ///     判断双浮点数a==0
        /// </summary>
        public static bool AeqZero(double a)
        {
            return MathV.Abs(a) < MDeps;
        }

        /// <summary>
        ///     判断浮点数a!=0
        /// </summary>
        public static bool AneqZero(float a)
        {
            return MathV.Abs(a) > MEps;
        }

        /// <summary>
        ///     判断浮点数a!=0
        /// </summary>
        public static bool AneqZero(double a)
        {
            return MathV.Abs(a) > MDeps;
        }

        /// <summary>
        ///     在指定值（包括）之间生成给定计数的线性间隔样本向量，
        ///     等效于MatLab_Lin-space，但计数为第一个参数而不是最后一个参数。
        /// </summary>
        public static float[] LinearSpaced(int count, float start, float stop)
        {
            switch (count)
            {
                case <= 0:
                    throw new ArgumentOutOfRangeException(nameof(count));
                case 1:
                    return new[] { stop };
            }

            var step = (stop - start) / (count - 1);
            var data = new float[count];
            for (var i = 0; i < data.Length; i++)
                data[i] = start + i * step;
            data[^1] = stop;
            return data;
        }

        /// <summary>
        ///     判断提供的32位整数是否为偶数
        /// </summary>
        public static bool IsEven(this int number)
        {
            return (number & 0x1) == 0x0;
        }

        /// <summary>
        ///     判断提供的64位整数是否为偶数
        /// </summary>
        public static bool IsEven(this long number)
        {
            return (number & 0x1) == 0x0;
        }

        /// <summary>
        ///     判断提供的32位整数是否为奇数
        /// </summary>
        public static bool IsOdd(this int number)
        {
            return (number & 0x1) == 0x1;
        }

        /// <summary>
        ///     判断提供的64位整数是否为奇数
        /// </summary>
        public static bool IsOdd(this long number)
        {
            return (number & 0x1) == 0x1;
        }

        /// <summary>
        ///     估计当前机器的浮点EPSILON值
        /// </summary>
        public static void EstimateEps(float centre)
        {
            Eps = 1f;
            while (Eps + centre > centre)
                Eps /= 2f;
        }

        /// <summary>
        ///     估计当前机器的双精度EPSILON值
        /// </summary>
        public static void EstimateDeps(double centre)
        {
            Deps = 1.0;
            while (Deps + centre > centre)
                Deps /= 2.0;
        }

        public static double HalfSquare(double x)
        {
            return Math.Pow(x, 2) / 2;
        }

        public static double TwoDomainFunction(double x, double y)
        {
            return x * y / 2;
        }

        public static bool IsValidParameterSet(double p)
        {
            return p is >= 0.0 and <= 1.0;
        }

        public static bool IsValidParameterSet(double a, double b)
        {
            return a >= 0.0 && b >= 0.0;
        }

        public static double StdDev(double p)
        {
            return Math.Sqrt(p * (1.0 - p));
        }

        public static double Variance(double p)
        {
            return p * (1.0 - p);
        }

        public static double Entropy(double p)
        {
            return -(p * Math.Log(p)) - (1.0 - p) * Math.Log(1.0 - p);
        }

        public static double Skewness(double p)
        {
            return (1.0 - 2.0 * p) / Math.Sqrt(p * (1.0 - p));
        }

        public static int Mode(double p)
        {
            return p > 0.5 ? 1 : 0;
        }

        public static int[] Modes(double p)
        {
            return p < 0.5 ? new[] { 0 } : p > 0.5 ? new[] { 1 } : new[] { 0, 1 };
        }

        public static double Median(double p)
        {
            return p < 0.5 ? 0.0 : p > 0.5 ? 1.0 : 0.5;
        }

        public static double Probability(double p, int k)
        {
            return k switch
            {
                0 => 1.0 - p,
                1 => p,
                _ => 0.0
            };
        }

        public static double ProbabilityLn(double p, int k)
        {
            if (k == 0) return Math.Log(1.0 - p);
            return k == 1 ? Math.Log(p) : double.NegativeInfinity;
        }

        public static double CumulativeDistribution(double p, double x)
        {
            return x switch
            {
                < 0.0 => 0.0,
                >= 1.0 => 1.0,
                _ => 1.0 - p
            };
        }

        public static double PMF(double p, int k)
        {
            if (p is not (>= 0.0 and <= 1.0)) return default;
            return k switch
            {
                0 => 1.0 - p,
                1 => p,
                _ => 0.0
            };
        }

        public static double PMFLn(double p, int k)
        {
            if (p is not (>= 0.0 and <= 1.0)) return default;
            if (k == 0) return Math.Log(1.0 - p);
            return k == 1 ? Math.Log(p) : double.NegativeInfinity;
        }

        public static double CDF(double p, double x)
        {
            if (p is not (>= 0.0 and <= 1.0)) return default;

            return x switch
            {
                < 0.0 => 0.0,
                >= 1.0 => 1.0,
                _ => 1.0 - p
            };
        }
    }

    /// <summary>
    ///     数学函数库E
    /// </summary>
    public static class MathE
    {
        public const StringComparison DefaultStringComparison = StringComparison.Ordinal;

        public static bool IsDefault<T>(this T value)
            where T : struct
        {
            return value.Equals(default(T));
        }

        public static IEnumerable<(T item, int index)> Indexed<T>(this IEnumerable<T> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));
            return Inner();

            IEnumerable<(T item, int index)> Inner()
            {
                var index = 0;
                foreach (var item in items)
                {
                    yield return (item, index);
                    ++index;
                }
            }
        }

        public static void Deconstruct<TKey, TValue>(this KeyValuePair<TKey, TValue> p, out TKey key, out TValue value)
        {
            key = p.Key;
            value = p.Value;
        }

        public static bool IsNullOrZeroItems(this IList list)
        {
            return list == null || list.Count == 0;
        }

        public static T FirstBasedOn<T>(this IList<T> list, Func<T, IComparable> order)
            where T : class
        {
            if (list.Count == 0)
                return null;
            var itemFirst = default(T);
            IComparable valueFirst = null;
            foreach (var item in list)
            {
                var actual = order(item);
                if (valueFirst != null && actual.CompareTo(valueFirst) >= 0) continue;
                valueFirst = actual;
                itemFirst = item;
            }

            return itemFirst;
        }

        public static T LastBasedOn<T>(this IList<T> list, Func<T, IComparable> order)
            where T : class
        {
            if (list.Count == 0)
                return null;

            var itemLast = default(T);
            IComparable valueLast = null;

            foreach (var item in list)
            {
                var actual = order(item);

                if (valueLast != null && actual.CompareTo(valueLast) < 0) continue;
                valueLast = actual;
                itemLast = item;
            }

            return itemLast;
        }

        public static List<TObj> SelectDistinctSorted<TObj>(this IList<TObj> list)
            where TObj : IComparable
        {
            var res = new SortedList<TObj, TObj>(list.Count);
            foreach (var item in list)
                if (!res.ContainsKey(item))
                    res.Add(item, item);

            return res.Values.ToList();
        }

        public static int CountDistinct<TObj, TResult>(this IList<TObj> list, Func<TObj, TResult> valCalculator)
        {
            var check = new HashSet<TResult>();

            foreach (var item in list)
            {
                var result = valCalculator(item);
                if (!check.Contains(result))
                    check.Add(result);
            }

            return check.Count;
        }


        public static List<TResult> SelectDistinctSorted<TObj, TResult>(this IList<TObj> list,
            Func<TObj, TResult> valCalculator)
        {
            var res = new SortedList<TResult, TResult>(list.Count);
            foreach (var item in list)
            {
                var result = valCalculator(item);
                if (!res.ContainsKey(result))
                    res.Add(result, result);
            }

            return res.Values.ToList();
        }

        public static List<string> SelectDistinctSortedIgnoreCase(this IList<string> list,
            Func<string, string> valCalculator)
        {
            var res = new SortedList<string, string>(list.Count, StringComparer.OrdinalIgnoreCase);

            foreach (var item in list)
            {
                var result = valCalculator(item);
                if (!res.ContainsKey(result))
                    res.Add(result, result);
            }

            return res.Values.ToList();
        }

        public static List<string> SelectDistinctSortedIgnoreCase(this IList<string> list)
        {
            var res = new SortedList<string, string>(list.Count, StringComparer.OrdinalIgnoreCase);

            foreach (var item in list)
                if (!res.ContainsKey(item))
                    res.Add(item, item);

            return res.Values.ToList();
        }

        public static List<TResult> SelectDistinctUnSorted<TObj, TResult>(this IList<TObj> list,
            Func<TObj, TResult> valCalculator)
        {
            var res = new List<TResult>();
            var containsCheck = new HashSet<TResult>();

            foreach (var item in list)
            {
                var result = valCalculator(item);
                if (containsCheck.Contains(result)) continue;
                containsCheck.Add(result);
                res.Add(result);
            }

            return res;
        }

        public static Dictionary<TKey, TValue> ToDictionary<TKey, TValue>(this Hashtable hash)
        {
            var res = new Dictionary<TKey, TValue>(hash.Count);
            foreach (var item in hash.Keys) res.Add((TKey)item, (TValue)hash[item]);
            return res;
        }


        public static Dictionary<TKey, TItem> ToDictionary<TItem, TKey>(this IList<TItem> list,
            Func<TItem, TKey> keyFunc)
        {
            return ToDictionary(list, keyFunc, x => x);
        }

        public static Dictionary<TKey, TValue> ToDictionary<TItem, TKey, TValue>(this IList<TItem> list,
            Func<TItem, TKey> keyFunc, Func<TItem, TValue> valueFunc)
        {
            var res = new Dictionary<TKey, TValue>(list.Count);

            foreach (var item in list) res.Add(keyFunc(item), valueFunc(item));

            return res;
        }

        public static HashSet<TItem> ToHashSetIgnoringDuplicates<TItem>(this IList<TItem> list)
            where TItem : IComparable<TItem>
        {
            var res = new HashSet<TItem>();

            foreach (var item in list)
                if (!res.Contains(item))
                    res.Add(item);

            return res;
        }


        public static HashSet<TItem> ToHashSet<TItem>(this IEnumerable<TItem> list) where TItem : IComparable<TItem>
        {
            var res = new HashSet<TItem>();

            foreach (var item in list) res.Add(item);

            return res;
        }

        public static HashSet<TItem> ToHashSet<TItem>(this IEnumerable<TItem> list, bool ignoreDup)
            where TItem : IComparable<TItem>
        {
            var res = new HashSet<TItem>();

            foreach (var item in list)
            {
                if (ignoreDup && res.Contains(item))
                    continue;

                res.Add(item);
            }

            return res;
        }

        public static HashSet<TKey> ToHashSet<TItem, TKey>(this IEnumerable<TItem> list, Func<TItem, TKey> keyFunc)
            where TKey : IComparable<TKey>
        {
            var res = new HashSet<TKey>();

            foreach (var item in list) res.Add(keyFunc(item));

            return res;
        }

        public static Dictionary<TKey, List<TItem>> GroupByAsDictionary<TItem, TKey>(this IEnumerable<TItem> list,
            Func<TItem, TKey> keyFunc)
        {
            return GroupByAsDictionary(list, keyFunc, x => x);
        }

        public static Dictionary<TKey, List<TValue>> GroupByAsDictionary<TItem, TKey, TValue>(
            this IEnumerable<TItem> list, Func<TItem, TKey> keyFunc, Func<TItem, TValue> valueFunc)
        {
            var res = new Dictionary<TKey, List<TValue>>();

            foreach (var item in list)
            {
                var key = keyFunc(item);
                var value = valueFunc(item);

                if (!res.TryGetValue(key, out var valuesList))
                {
                    valuesList = new List<TValue>();
                    res.Add(key, valuesList);
                }

                valuesList.Add(value);
            }

            return res;
        }


        public static Dictionary<TKey1, Dictionary<TKey2, List<TItem>>>
            GroupByAsDictionaryOfDictionaries<TItem, TKey1, TKey2>(this IEnumerable<TItem> list,
                Func<TItem, TKey1> keyFunc1, Func<TItem, TKey2> keyFunc2)
        {
            var res = new Dictionary<TKey1, Dictionary<TKey2, List<TItem>>>();

            foreach (var item in list)
            {
                var key1 = keyFunc1(item);
                var key2 = keyFunc2(item);

                if (!res.TryGetValue(key1, out var dictionary1))
                {
                    dictionary1 = new Dictionary<TKey2, List<TItem>>();
                    res.Add(key1, dictionary1);
                }

                if (!dictionary1.TryGetValue(key2, out var valuesList))
                {
                    valuesList = new List<TItem>();
                    dictionary1.Add(key2, valuesList);
                }

                valuesList.Add(item);
            }

            return res;
        }

        public static Dictionary<TKey, HashSet<TValue>> GroupByAsDictionaryHash<TItem, TKey, TValue>(
            this IEnumerable<TItem> list, Func<TItem, TKey> keyFunc, Func<TItem, TValue> valueFunc)
        {
            var res = new Dictionary<TKey, HashSet<TValue>>();

            foreach (var item in list)
            {
                var key = keyFunc(item);
                var value = valueFunc(item);

                if (!res.TryGetValue(key, out var valuesList))
                {
                    valuesList = new HashSet<TValue>();
                    res.Add(key, valuesList);
                }

                valuesList.Add(value);
            }

            return res;
        }

        public static Dictionary<TKey, TValue> ToDictionaryIgnoringDuplicateKeys<TItem, TKey, TValue>(
            this IList<TItem> list, Func<TItem, TKey> keyFunc, Func<TItem, TValue> valueFunc)
        {
            var res = new Dictionary<TKey, TValue>(list.Count);

            foreach (var item in list)
            {
                var key = keyFunc(item);
                if (!res.ContainsKey(key))
                    res.Add(key, valueFunc(item));
            }

            return res;
        }

        public static List<KeyValuePair<TKey, int>> ToSortedArrayByValue<TKey>(this Dictionary<TKey, int> list)
        {
            var res = list.ToList();

            res.Sort((x, y) => -x.Value.CompareTo(y.Value));


            return res;
        }

        public static List<KeyValuePair<TKey, TValue>> ToSortedArrayByKey<TKey, TValue>(
            this Dictionary<TKey, TValue> list)
            where TKey : IComparable<TKey>
        {
            var res = list.ToList();
            res.Sort((x, y) => x.Key.CompareTo(y.Key));
            return res;
        }

        public static void AddOrOverride<TKey, TValue>(this Dictionary<TKey, TValue> list, TKey key, TValue value)
        {
            list[key] = value;
        }

        public static TValue GetOrAddValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key,
            Func<TKey, TValue> newValueCreator)
        {
            if (dictionary.TryGetValue(key, out var res))
                return res;

            res = newValueCreator(key);
            dictionary.Add(key, res);
            return res;
        }

        public static TValue GetOrCreateNew<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
            where TValue : new()
        {
            if (dictionary.TryGetValue(key, out var res))
                return res;

            res = new TValue();
            dictionary.Add(key, res);
            return res;
        }

        public static TValue GetOrCalculate<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key,
            Func<TKey, TValue> valueCalculator)
        {
            if (dictionary != null && dictionary.TryGetValue(key, out var res))
                return res;

            return valueCalculator(key);
        }

        public static TValue GetOrNull<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
            where TValue : class
        {
            if (dictionary != null && dictionary.TryGetValue(key, out var res))
                return res;

            return null;
        }

        public static void Set<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
                dictionary[key] = value;
            else
                dictionary.Add(key, value);
        }

        public static string JoinToStringFormat<T>(this IEnumerable<T> list)
            where T : IFormattable
        {
            return list.JoinToStringFormat(",");
        }

        public static string JoinToStringFormat<T>(this IEnumerable<T> list, string delimiter)
            where T : IFormattable
        {
            return list.JoinToStringFormat(delimiter, null);
        }

        public static string JoinToStringFormat<T>(this IEnumerable<T> list, string delimiter, IFormatProvider info)
            where T : IFormattable
        {
            var sb = new StringBuilder();

            var primer = true;

            foreach (var x in list)
            {
                if (primer)
                    primer = false;
                else
                    sb.Append(delimiter);
                sb.Append(x.ToString(null, info));
            }

            return sb.ToString();
        }

        public static string JoinToString<T>(this IEnumerable<T> list)
        {
            return list.JoinToString(",");
        }

        public static string JoinOnePerLine<T>(this IEnumerable<T> list)
        {
            return list.JoinToString(Environment.NewLine) + Environment.NewLine;
        }

        public static string JoinToString(this IEnumerable<string> list, string delimiter)
        {
            if (list == null)
                return Empty;

            StringBuilder sb;
            if (list is not IList<string> listTyped)
            {
                sb = new StringBuilder();
            }
            else
            {
                var largo = listTyped.Sum(x => x.Length);
                sb = new StringBuilder(largo + delimiter.Length * listTyped.Count);
            }

            var primer = true;

            foreach (var x in list)
            {
                if (primer)
                    primer = false;
                else
                    sb.Append(delimiter);
                sb.Append(x);
            }

            return sb.ToString();
        }

        public static string JoinToString<T>(this IEnumerable<T> list, string delimiter)
        {
            if (list == null)
                return Empty;

            var sb = list is IList<T> list1 ? new StringBuilder(list1.Count * 5) : new StringBuilder();

            var primero = true;

            foreach (var x in list)
            {
                if (primero)
                    primero = false;
                else
                    sb.Append(delimiter);
                sb.Append(x);
            }

            return sb.ToString();
        }

        public static bool IsOn(this byte source, params byte[] list)
        {
            return IsOn<byte>(source, list);
        }

        public static bool IsOn(this short source, params short[] list)
        {
            return IsOn<short>(source, list);
        }

        public static bool IsOn<T>(this T source, params T[] list) where T : IComparable
        {
            return list.Any(t => t.CompareTo(source) == 0);
        }

        public static bool IsOn<T>(this T source, IEnumerable<T> list) where T : IComparable
        {
            return list.Any(item => item.CompareTo(source) == 0);
        }

        public static bool IsOn<T>(this T source, HashSet<T> list) where T : IComparable
        {
            return list.Contains(source);
        }

        public static void ShuffleInPlace<T>(this IList<T> items)
        {
            ShuffleInPlace(items, 4);
        }

        public static void ShuffleInPlace<T>(this IList<T> items, int times)
        {
            for (var j = 0; j < times; j++)
            {
                var rnd = new Random((int)(DateTime.Now.Ticks % int.MaxValue) - j);

                for (var i = 0; i < items.Count; i++)
                {
                    var index = rnd.Next(items.Count - 1);
                    (items[index], items[i]) = (items[i], items[index]);
                }
            }
        }

        public static List<T> ShuffleToNewList<T>(this IList<T> items)
        {
            return ShuffleToNewList(items, 4);
        }

        public static List<T> ShuffleToNewList<T>(this IList<T> items, int times)
        {
            var res = new List<T>(items);
            res.ShuffleInPlace(times);
            return res;
        }

        public static TSource[] ToSortedArray<TSource>(this IEnumerable<TSource> source, Comparison<TSource> comparer)
        {
            var res = source.ToArray();
            Array.Sort(res, comparer);
            return res;
        }

        public static TSource[] ToSortedArray<TSource>(this IEnumerable<TSource> source)
            where TSource : IComparable<TSource>
        {
            var res = source.ToArray();
            Array.Sort(res);
            return res;
        }

        public static List<TSource> RemoveDuplicates<TSource>(this IList<TSource> values)
        {
            var res = new List<TSource>(values.Count);
            var duplicateCheck = new HashSet<TSource>();

            foreach (var value in values)
            {
                if (duplicateCheck.Contains(value))
                    continue;

                duplicateCheck.Add(value);
                res.Add(value);
            }

            return res;
        }

        public static List<TSource> RemoveDuplicates<TSource, TCheck>(this IList<TSource> values,
            Func<TSource, TCheck> dupliCheck)
        {
            var duplicateCheck = new HashSet<TCheck>();
            var res = new List<TSource>(values.Count);

            foreach (var value in values)
            {
                var val = dupliCheck(value);

                if (duplicateCheck.Contains(val))
                    continue;

                duplicateCheck.Add(val);
                res.Add(value);
            }

            return res;
        }


        public static List<string> RemoveDuplicatesIgnoreCase(this IList<string> values)
        {
            var duplicateCheck = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var res = new List<string>(values.Count);
            foreach (var value in values)
            {
                if (duplicateCheck.Contains(value)) continue;

                duplicateCheck.Add(value);
                res.Add(value);
            }

            return res;
        }

        public static List<TSource> MoveToFirst<TSource>(this List<TSource> source, TSource element)
        {
            if (!source.Contains(element))
                return source;

            source.Remove(element);
            source.Insert(0, element);
            return source;
        }

        public static IEnumerable<List<TSource>> SplitInGroups<TSource>(this IEnumerable<TSource> values, int groupSize)
        {
            if (values is List<TSource> asList && asList.Count <= groupSize)
            {
                yield return asList;
                yield break;
            }

            var currentList = new List<TSource>(groupSize);

            foreach (var value in values)
            {
                if (currentList.Count >= groupSize)
                {
                    yield return currentList;
                    currentList = new List<TSource>(groupSize);
                }

                currentList.Add(value);
            }

            if (currentList.Count > 0)
                yield return currentList;
        }

        public static List<List<TSource>> SplitInGroupsRemovingDuplicates<TSource>(this IEnumerable<TSource> values,
            int groupSize)
        {
            var res = new List<List<TSource>>();

            var duplicateCheck = new HashSet<TSource>();
            var currentList = new List<TSource>(groupSize);

            foreach (var value in values)
            {
                if (duplicateCheck.Contains(value))
                    continue;

                duplicateCheck.Add(value);

                if (currentList.Count >= groupSize)
                {
                    res.Add(currentList);
                    currentList = new List<TSource>(groupSize);
                }

                currentList.Add(value);
            }

            if (currentList.Count > 0)
                res.Add(currentList);

            return res;
        }

        public static void AddDictionary<TKey, TVal>(this Dictionary<TKey, TVal> me, Dictionary<TKey, TVal> other)
        {
            foreach (var src in other) me.Add(src.Key, src.Value);
        }

        public static T[] FindAll<T>(this T[] me, Predicate<T> condition)
        {
            return Array.FindAll(me, condition);
        }

        public static bool Contains<T>(this IEnumerable<T> me, Predicate<T> condition)
        {
            return me.Any(val => condition(val));
        }

        public static List<string> ToStringList<T>(this IEnumerable<T> me, Func<T, string> stringConverter)
        {
            return me.Select(stringConverter).ToList();
        }


        public static List<Tuple<TKey, TValue>> ToTuple<TKey, TValue>(this Dictionary<TKey, TValue> me)
        {
            return me.Select(val => Tuple.Create(val.Key, val.Value)).ToList();
        }

        public static int IndexOfEnd(this string value, string find, int? startIndex = null,
            StringComparison comparisonType = DefaultStringComparison)
        {
            var pos = value.IndexOf(find, startIndex ?? 0, comparisonType);
            if (pos > -1)
                pos += find.Length;
            return pos;
        }

        public static IEnumerable<int> AllIndexesOf(this string value, string find,
            StringComparison comparisonType = DefaultStringComparison)
        {
            var pos = 0;
            while ((pos = value.IndexOf(find, pos, comparisonType)) > -1)
            {
                yield return pos;
                pos += find.Length;
            }
        }

        public static IEnumerable<KeyValuePair<string, int>> AllIndexesOf(this string value, IEnumerable<string> find,
            StringComparison comparisonType = DefaultStringComparison)
        {
            var results = new ConcurrentBag<KeyValuePair<string, int>>();
            Parallel.ForEach(find, search =>
            {
                var r = AllIndexesOf(value, search, comparisonType)
                    .Select(pos => new KeyValuePair<string, int>(search, pos));
                foreach (var kvp in r) results.Add(kvp);
            });
            return results;
        }

        public static IOrderedEnumerable<KeyValuePair<string, int>> AllSortedIndexesOf(this string value,
            IEnumerable<string> find, StringComparison comparisonType = DefaultStringComparison)
        {
            var indexes = AllIndexesOf(value, find, comparisonType);
            return indexes.OrderBy(i => i.Value);
        }

        public static string TextBefore(this string value, string find,
            StringComparison comparisonType = DefaultStringComparison)
        {
            var pos = value.IndexOf(find, comparisonType);
            if (pos == -1)
                pos = 0;
            return value[..pos];
        }

        public static string TextAfter(this string value, string find,
            StringComparison comparisonType = DefaultStringComparison)
        {
            var pos = value.IndexOfEnd(find, null, comparisonType);
            if (pos == -1)
                pos = value.Length;
            return value[pos..];
        }

        public static string TextBetween(this string value, string start, string end,
            StringComparison comparisonType = DefaultStringComparison)
        {
            return value.TextAfter(start, comparisonType).TextBefore(end, comparisonType);
        }

        public static IEnumerable<string> AllTextBetween(this string value, string start, string end,
            StringComparison comparisonType = DefaultStringComparison)
        {
            var results = value.AllSortedIndexesOf(new[] { start, end }, comparisonType);
            var nextIsStart = true;
            var postpartum = -1;
            foreach (var v in results)
            {
                if (v.Key != (nextIsStart ? start : end) || v.Value < postpartum) continue;
                if (nextIsStart)
                {
                    postpartum = v.Value + start.Length;
                    nextIsStart = false;
                }
                else
                {
                    yield return value[postpartum..(v.Value - postpartum)];
                    nextIsStart = true;
                    postpartum = v.Value + end.Length;
                }
            }
        }

        public static string ReplaceAll(this string haystack, IEnumerable<string> find, string replaceWith)
        {
            var pos = 0;
            var sb = new StringBuilder();
            foreach (var match in haystack.AllSortedIndexesOf(find))
            {
                sb.Append(haystack[pos..(match.Value - pos)]);
                sb.Append(replaceWith);
                pos = match.Value + match.Key.Length;
            }

            sb.Append(haystack[pos..^pos]);
            return sb.ToString();
        }

        public static bool IsValueValid(this object value)
        {
            if (value == null)
                return false;
            var enumType = value.GetType();
            return enumType.GetTypeInfo().BaseType == typeof(Enum) && Enum.IsDefined(enumType, value);
        }

        public static T IfNull<T>(this T obj, Action action)
        {
            if (obj == null) action();
            return obj;
        }

        public static T IfNull<T>(this T obj, Func<T> func)
        {
            return obj ?? func();
        }

        public static T IfNotNull<T>(this T obj, Action<T> action)
        {
            if (obj != null) action(obj);
            return obj;
        }

        public static T IfNotNull<T>(this T obj, Action action)
        {
            if (obj != null) action();
            return obj;
        }

        public static IEnumerable<T> Alternate<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            using var e1 = first.GetEnumerator();
            using var e2 = second.GetEnumerator();
            while (e1.MoveNext() && e2.MoveNext())
            {
                yield return e1.Current;
                yield return e2.Current;
            }
        }

        public static T NextItem<T>(this IEnumerable<T> @this)
        {
            var temp = @this.ToList();
            return temp[MathV.Next(0, temp.Count)];
        }

        public static void Each<T>(this IEnumerable<T> @this, Action<T> action)
        {
            foreach (var item in @this)
                action(item);
        }

        public static void NestedEach<T, T2>(this IEnumerable<T> outer,
            IEnumerable<T2> inner,
            Action<T, T2> action)
        {
            var enumerable = inner as T2[] ?? inner.ToArray();
            foreach (var item in outer)
                foreach (var item2 in enumerable)
                    action(item, item2);
        }

        public static void NestedEachWithOuter<T, T2>(this IEnumerable<T> inner,
            IEnumerable<T2> outer,
            Action<T2, T> action)
        {
            var enumerable = inner as T[] ?? inner.ToArray();
            foreach (var item in outer)
                foreach (var item2 in enumerable)
                    action(item, item2);
        }

        public static IEnumerable<TOut> SequenceJoin<T, T2, TOut>(this IEnumerable<T> seq1,
            IEnumerable<T2> seq2,
            Func<T, T2, TOut> action)
        {
            using var rator1 = seq1.GetEnumerator();
            using var rator2 = seq2.GetEnumerator();

            while (rator1.MoveNext() && rator2.MoveNext()) yield return action(rator1.Current, rator2.Current);
        }

        public static int GetDecimalDigits(this decimal number, bool ignoreTrailingZeros)
        {
            if (ignoreTrailingZeros)
            {
                var fullString = $"{number:#.################################}";
                if ((number == 0) | !fullString.Contains(".")) return 0;

                var decimalsString = fullString.Split('.').LastOrDefault();
                return decimalsString?.Length ?? 0;
            }

            var bits = decimal.GetBits(number);
            var bytes = BitConverter.GetBytes(bits[3]);
            var decimalsInPrice = bytes[2];
            return decimalsInPrice;
        }

        public static decimal RoundUp(this decimal value, int decimalPlaces)
        {
            return Round(value, decimalPlaces, true);
        }

        public static decimal RoundDown(this decimal value, int decimalPlaces)
        {
            return Round(value, decimalPlaces, false);
        }

        public static decimal Round(decimal value, int decimals, bool up)
        {
            var roundMultiplicator = (decimal)Math.Pow(10, decimals);
            var multiplicatedAmount = value * roundMultiplicator;
            var powerAmountRounded = up ? Math.Ceiling(multiplicatedAmount) : Math.Floor(multiplicatedAmount);
            var roundedValue = powerAmountRounded / roundMultiplicator;
            return roundedValue;
        }

        public static int Mod(this int a, int b)
        {
            return a % b;
        }

        public static bool IsDivisibleBy(this int denominator, int dividend)
        {
            return denominator % dividend == 0;
        }

        public static int Push<T>(ref T[] array, T item)
        {
            var len = array.Length;
            var res = new T[len + 1];

            array.CopyTo(res, 0);
            array = res;
            array[len] = item;

            return array.Length;
        }

        public static T Pop<T>(ref T[] array)
        {
            var len = array.Length;
            var res = new T[len - 1];
            var popped = array[len - 1];

            if (len > 1)
                for (var i = 0; i < len - 1; i++)
                    res[i] = array[i];

            array = res;

            return popped;
        }

        public static T Shift<T>(ref T[] array)
        {
            var len = array.Length;
            var res = new T[len - 1];
            var shifted = array[0];

            while (len > 1)
                res[--len - 1] = array[len];

            array = res;

            return shifted;
        }

        public static T[] Splice<T>(ref T[] array, int index, int length, params T[] args)
        {
            throw new NotImplementedException();
        }

        public static dynamic[] Map<T>(this T[] array, Func<T, dynamic> fun)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            var len = array.Length;
            var res = new dynamic[len];

            for (var i = 0; i < len; i++)
            {
                var item = array[i];
                res[i] = fun.Invoke(item);
            }

            return res;
        }

        public static T[] Filter<T>(this T[] array, Func<T, bool> fun)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));

            var len = array.Length;
            var res = new T[] { };

            for (var i = 0; i < len; i++)
            {
                var value = array[i];

                if (fun.Invoke(value))
                    Push(ref res, value);
            }

            return res;
        }

        public static string Join(this string[] array, string separator)
        {
            if (array == null) throw new ArgumentNullException(nameof(array));
            if (separator == null) throw new ArgumentNullException(nameof(separator));

            return string.Join(separator, array);
        }

        public static T[] Flatten<T>(this Array data)
        {
            var list = new List<T>();
            var stack = new Stack<IEnumerator>();
            stack.Push(data.GetEnumerator());
            do
            {
                for (var iterator = stack.Pop(); iterator!.MoveNext();)
                    if (iterator.Current is Array)
                    {
                        stack.Push(iterator);
                        iterator = (iterator.Current as IEnumerable)?.GetEnumerator();
                    }
                    else
                    {
                        list.Add((T)iterator.Current);
                    }
            } while (stack.Count > 0);

            return list.ToArray();
        }

        public static IEnumerable<T> Randomize<T>(this IEnumerable<T> source)
        {
            return source.OrderBy(_ => MathV.RandomV.Next());
        }

        public static T NextOf<T>(this IList<T> list, T item)
        {
            return list[list.IndexOf(item) + 1 == list.Count ? 0 : list.IndexOf(item) + 1];
        }

        public static IList<T> JoinList<T>(this IList<T> list, IList<T> listToJoin, bool removeDuplicates = false)
        {
            var thisList = (List<T>)list;
            thisList.AddRange(listToJoin);

            if (removeDuplicates) thisList.HashDistinct();

            return thisList;
        }

        public static string[] Split(this string data, string separator)
        {
            return data == null ? new string[] { } : data.Split(separator.ToCharArray());
        }

        public static IEnumerable<T> Return<T>(this T singleValue)
        {
            return new[] { singleValue };
        }

        public static IEnumerable<Tuple<TA, TB>> Outer<TA, TB>(
            this IEnumerable<TA> these,
            IEnumerable<TB> those)
        {
            Contract.Requires(these != null);
            Contract.Requires(those != null);
            return from a in these
                   from b in those
                   select Tuple.Create(a, b);
        }

        public static TA ArgMax<TA, TV>(
            this IEnumerable<TA> collection,
            Func<TA, TV> function)
            where TV : IComparable<TV>
        {
            Contract.Requires(collection != null);
            Contract.Requires(function != null);
            return ArgComp(collection, function, GreaterThan);
        }

        private static bool GreaterThan<TA>(TA first, TA second) where TA : IComparable<TA>
        {
            return first.CompareTo(second) > 0;
        }

        public static TA ArgMin<TA, TV>(
            this IEnumerable<TA> collection,
            Func<TA, TV> function)
            where TV : IComparable<TV>
        {
            Contract.Requires(collection != null);
            Contract.Requires(function != null);
            return ArgComp(collection, function, LessThan);
        }

        private static bool LessThan<TA>(TA first, TA second) where TA : IComparable<TA>
        {
            return first.CompareTo(second) < 0;
        }

        private static TA ArgComp<TA, TV>(
            IEnumerable<TA> collection,
            Func<TA, TV> function,
            Func<TV, TV, bool> accept)
            where TV : IComparable<TV>
        {
            Contract.Requires(collection != null);
            Contract.Requires(function != null);
            Contract.Requires(accept != null);

            var isSet = false;
            var maxArg = default(TA);
            var extremeValue = default(TV);

            foreach (var item in collection)
            {
                var value = function(item);
                if (isSet && !accept(value, extremeValue)) continue;
                maxArg = item;
                extremeValue = value;
                isSet = true;
            }

            return maxArg;
        }

        public static ArgumentValuePair<TA, TV> ArgAndMax<TA, TV>(
            this IEnumerable<TA> collection,
            Func<TA, TV> function)
            where TV : IComparable<TV>
        {
            Contract.Requires(collection != null);
            Contract.Requires(function != null);

            return ArgAndComp(collection, function, GreaterThan);
        }

        public static ArgumentValuePair<TA, TV> ArgAndMin<TA, TV>(
            this IEnumerable<TA> collection,
            Func<TA, TV> function)
            where TV : IComparable<TV>
        {
            Contract.Requires(collection != null);
            Contract.Requires(function != null);

            return ArgAndComp(collection, function, LessThan);
        }

        public static ArgumentValuePair<TA, TV> ArgAndComp<TA, TV>(
            IEnumerable<TA> collection,
            Func<TA, TV> function,
            Func<TV, TV, bool> accept)
            where TV : IComparable<TV>
        {
            Contract.Requires(collection != null);
            Contract.Requires(function != null);
            Contract.Requires(accept != null);

            var isSet = false;
            var maxArg = default(TA);
            var extremeValue = default(TV);

            foreach (var item in collection)
            {
                var value = function(item);
                if (isSet && !accept(value, extremeValue)) continue;
                maxArg = item;
                extremeValue = value;
                isSet = true;
            }

            return new ArgumentValuePair<TA, TV> { Argument = maxArg, Value = extremeValue };
        }

        public static void ZipDo<T, TU>(
            this IEnumerable<T> first,
            IEnumerable<TU> second,
            Action<T, TU> action)
        {
            Contract.Requires(first != null);
            Contract.Requires(second != null);
            Contract.Requires(action != null);

            using var firstEnumerator = first.GetEnumerator();
            using var secondEnumerator = second.GetEnumerator();
            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
                action(firstEnumerator.Current, secondEnumerator.Current);
        }

        public static IEnumerable<T> PairwiseDo<T>(
            this IEnumerable<T> enumerable,
            Action<T, T> action)
        {
            Contract.Requires(enumerable != null);
            Contract.Requires(action != null);
            Contract.Requires(enumerable.First() != null);

            var pairwiseDo = enumerable as T[] ?? enumerable.ToArray();
            pairwiseDo.ZipDo(pairwiseDo.Skip(1), action);

            return pairwiseDo;
        }

        public static IEnumerable<TU> Pairwise<T, TU>(
            this IEnumerable<T> enumerable,
            Func<T, T, TU> resultSelector)
        {
            Contract.Requires(enumerable != null);
            Contract.Requires(resultSelector != null);
            Contract.Requires(enumerable.First() != null);

            var enumerable1 = enumerable as T[] ?? enumerable.ToArray();
            return enumerable1.Zip(enumerable1.Skip(1), resultSelector);
        }

        public static T MustBe<T>(this object self)
            where T : class
        {
            if (self is not T that)
                throw new InvalidOperationException(
                    $"Expected object {self} to have type {typeof(T)}");
            return that;
        }

        public static Func<TB, TA, TC> Flip<TA, TB, TC>(this Func<TA, TB, TC> f)
        {
            return (b, a) => f(a, b);
        }

        public static Func<TB, Func<TA, TC>> Flip<TA, TB, TC>(this Func<TA, Func<TB, TC>> f)
        {
            return b => a => f(a)(b);
        }

        /// <summary>
        ///     阶乘
        /// </summary>
        public static int Factorial(this int n)
        {
            if (n <= 1) return n;
            var res = n;
            for (var i = 1; i < n; ++i) res *= i;
            return res;
        }

        public static bool TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key,
            out TValue value, TValue defaultValue)
        {
            if (dictionary.TryGetValue(key, out var result))
            {
                value = result;
                return true;
            }

            value = defaultValue;
            return false;
        }

        public static Func<Task> WrapTask(this Action action)
        {
            return () =>
            {
                action.Invoke();
                return Task.CompletedTask;
            };
        }

        public static Func<T, Task> WrapTask<T>(this Action<T> action)
        {
            return t =>
            {
                action.Invoke(t);
                return Task.CompletedTask;
            };
        }

        public static Func<T1, T2, Task> WrapTask<T1, T2>(this Action<T1, T2> action)
        {
            return (t1, t2) =>
            {
                action.Invoke(t1, t2);
                return Task.CompletedTask;
            };
        }

        public static Func<T1, T2, T3, Task> WrapTask<T1, T2, T3>(this Action<T1, T2, T3> action)
        {
            return (t1, t2, t3) =>
            {
                action.Invoke(t1, t2, t3);
                return Task.CompletedTask;
            };
        }

        public static Func<T1, T2, T3, T4, Task> WrapTask<T1, T2, T3, T4>(this Action<T1, T2, T3, T4> action)
        {
            return (t1, t2, t3, t4) =>
            {
                action.Invoke(t1, t2, t3, t4);
                return Task.CompletedTask;
            };
        }

        public static bool AddIfNotContains<T>(this ICollection<T> @this, T value)
        {
            if (@this.IsReadOnly) return false;
            if (@this.Contains(value)) return false;
            @this.Add(value);
            return true;
        }

        public static bool HasValue<T>([NotNullWhen(true)] this ICollection<T> @this)
        {
            return @this is { Count: > 0 };
        }

        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source,
            int chunkSize)
        {
            var count = 0;
            var chunk = new List<T>(chunkSize);
            foreach (var item in source)
            {
                chunk.Add(item);
                count++;
                if (count != chunkSize) continue;
                yield return chunk.AsEnumerable();
                chunk = new List<T>(chunkSize);
                count = 0;
            }

            if (count > 0) yield return chunk.AsEnumerable();
        }

        public static IEnumerable<T> Or<T>(this IEnumerable<T> source, IEnumerable<T> or)
        {
            var enumerable = source as T[] ?? source.ToArray();
            return enumerable.IsEmpty() ? or : enumerable;
        }

        public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, int parts)
        {
            var i = 0;
            var splits = source.GroupBy(_ => i++ % parts)
                .Select(g => g.Select(x => x));
            return splits;
        }

        public static bool TryParse<T>(this string name, out T result, bool ignoreCase = false)
            where T : struct
        {
            return Enum.TryParse(name, ignoreCase, out result);
        }

        public static T Parse<T>(this string name, bool ignoreCase = false)
            where T : struct
        {
            return (T)Enum.Parse(typeof(T), name, ignoreCase);
        }

        public static StringBuilder AppendLine(this StringBuilder sb, string format, params object[] args)
        {
            sb.AppendLine(Format(format, args));
            return sb;
        }

        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            if (assembly == null) return Enumerable.Empty<Type>();
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
            catch (Exception)
            {
                return Enumerable.Empty<Type>();
            }
        }

        public static bool IsAuthenticated(this ClaimsPrincipal principal)
        {
            return principal?.Identity != null && principal.Identity.IsAuthenticated;
        }

        public static Dictionary<TKey, TValue> Merge<TKey, TValue>(this Dictionary<TKey, TValue> left,
            Dictionary<TKey, TValue> right, bool takeLastKey = false)
        {
            if (left == null || right == null) return left;
            foreach (var entry in right)
            {
                if (!left.ContainsKey(entry.Key))
                {
                    left.Add(entry.Key, entry.Value);
                    continue;
                }

                if (!takeLastKey) continue;
                left.Remove(entry.Key);
                left.Add(entry.Key, entry.Value);
            }

            return left;
        }

        public static bool IsPrimitive(this Type type)
        {
            if (type == typeof(string)) return true;
            return type.IsValueType & type.IsPrimitive;
        }

        public static IEnumerable<T> Traverse<T>(
            this IEnumerable<T> source,
            Func<T, IEnumerable<T>> recurse)
        {
            foreach (var item in source)
            {
                yield return item;
                foreach (var nestedItem in Traverse(recurse(item), recurse)) yield return nestedItem;
            }
        }

        public static void RemoveWhere<T>(this ICollection<T> @this, Func<T, bool> predicate)
        {
            var list = @this.Where(predicate).ToList();
            foreach (var item in list) @this.Remove(item);
        }

        public static bool AddIf<T>(this ICollection<T> @this, Func<T, bool> predicate, T value)
        {
            if (!predicate(value)) return false;
            @this.Add(value);
            return true;
        }

        public static void ThrowIf<T>(this Exception exception, Func<T, bool> predicate, T parameter)
        {
            if (!predicate(parameter)) return;
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));
            throw exception;
        }

        public static IEnumerable<T> ShuffleByDictionary<T>(this IEnumerable<T> list)
        {
            if (list == null)
                return default;
            var dict = new Dictionary<int, T>();
            var enumerable = list.ToArray();
            foreach (var item in enumerable)
            {
                int key;
                do
                {
                    key = MathV.NextInt(0, enumerable.Count());
                } while (dict.ContainsKey(key));

                dict.Add(key, item);
            }

            return dict.OrderBy(e => e.Key).Select(e => e.Value);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> list)
        {
            if (list == null)
                return default;
            var arr = MathV.Shuffle(list.ToArray());
            return arr;
        }

        public static IEnumerable<TSource> CycleIterator<TSource>(IEnumerable<TSource> source)
        {
            var elementBuffer = source is not ICollection<TSource> collection
                ? new List<TSource>()
                : new List<TSource>(collection.Count);
            foreach (var element in source)
            {
                yield return element;
                elementBuffer.Add(element);
            }

            if (elementBuffer.IsEmpty()) yield break;
            var index = 0;
            while (true)
            {
                yield return elementBuffer[index];
                index = (index + 1) % elementBuffer.Count;
            }
        }

        public static IEnumerable<TSource> ShuffleIterator<TSource>(IEnumerable<TSource> source)
        {
            var elements = source.ToArray();
            for (var n = 0; n < elements.Length; n++)
            {
                var k = MathV.RandomV.Next(n, elements.Length);
                yield return elements[k];
                elements[k] = elements[n];
            }
        }

        public static DateTime ToMinutePrecision(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, 0);
        }

        public static DateTime? ToMinutePrecision(this DateTime? value)
        {
            return value?.ToMinutePrecision();
        }

        public static DateTime ToSecondPrecision(this DateTime value)
        {
            return new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
        }

        public static DateTime? ToSecondPrecision(this DateTime? value)
        {
            if (value.HasValue)
                return value.Value.ToSecondPrecision();
            return null;
        }

        public static DateTime To10MsPrecision(this DateTime value)
        {
            return DateTime.Parse(value.ToString("MM/dd/yyyy HH:mm:ss.FF", CultureInfo.InvariantCulture),
                CultureInfo.InvariantCulture);
        }

        public static DateTime? To10MsPrecision(this DateTime? value)
        {
            if (value.HasValue)
                return value.Value.To10MsPrecision();
            return null;
        }

        public static DateTime To100MsPrecision(this DateTime value)
        {
            return DateTime.Parse(value.ToString("MM/dd/yyyy HH:mm:ss.F", CultureInfo.InvariantCulture),
                CultureInfo.InvariantCulture);
        }

        public static DateTime? To100MsPrecision(this DateTime? value)
        {
            if (value.HasValue)
                return value.Value.To100MsPrecision();
            return null;
        }

        public static string ToOracleDate(this DateTime value)
        {
            return Format(CultureInfo.InvariantCulture, "TO_DATE('{0:MM/dd/yyyy HH:mm:ss}','MM/DD/YYYY HH24:MI:SS')",
                value);
        }

        public static string ToOracleDate(this DateTime? value)
        {
            return value.HasValue ? value.Value.ToOracleDate() : "null";
        }

        public static bool EqualWithinTolerance(this DateTime objectUnderTest, DateTime comparisonValue,
            TimeSpan tolerance)
        {
            var duration = objectUnderTest.Subtract(comparisonValue).Duration();
            var comparisonResult = duration.CompareTo(tolerance);
            return comparisonResult <= 0;
        }

        public static double StdDev<T>(this IEnumerable<T> values)
        {
            var enumerable = values.ToList();
            var count = enumerable.Count();
            if (count < 2)
                return default;
            var avg = enumerable.Average(v => Convert.ToDouble(v, CultureInfo.CurrentCulture));
            var sum = enumerable.Sum(d =>
                (Convert.ToDouble(d, CultureInfo.CurrentCulture) - avg) *
                (Convert.ToDouble(d, CultureInfo.CurrentCulture) - avg));
            return Math.Sqrt(sum / count);
        }

        public static double Median<T>(this IEnumerable<T> values)
        {
            var enumerable = values.ToList();
            var count = enumerable.Count();
            if (count < 2)
                return default;
            var sortedValues = enumerable.OrderBy(v => v).ToArray();
            double result;
            if (count % 2 == 0)
            {
                var upperValue = Convert.ToInt32(count / 2);
                result = (Convert.ToDouble(sortedValues[upperValue], CultureInfo.CurrentCulture) +
                          Convert.ToDouble(sortedValues[upperValue - 1], CultureInfo.CurrentCulture)) / 2;
            }
            else
            {
                var middleValue = Convert.ToInt32(Math.Floor(Convert.ToDouble(count) / 2));
                result = Convert.ToDouble(sortedValues[middleValue], CultureInfo.CurrentCulture);
            }

            return result;
        }

        public static double Range<T>(this IEnumerable<T> values)
        {
            var enumerable = values.ToList();
            var count = enumerable.Count();
            if (count < 2)
                return default;
            var min = Convert.ToDouble(enumerable.Min(), CultureInfo.CurrentCulture);
            var max = Convert.ToDouble(enumerable.Max(), CultureInfo.CurrentCulture);
            return max - min;
        }

        public static T[] Add<T>(this T[] array, T item)
        {
            var length = array.Length;
            Array.Resize(ref array, length + 1);
            array[length] = item;
            return array;
        }

        public static T[] AddUnique<T>(this T[] array, T item)
        {
            return item.In(array) ? array : array.Add(item);
        }

        public static T[] AddRange<T>(this T[] array, T[] collection)
        {
            var length = array.Length;
            var collectionLength = collection.Length;
            Array.Resize(ref array, length + collectionLength);
            collection.CopyTo(array, length);
            return array;
        }

        public static bool Contains<T>(this T[] array, T item)
        {
            return item.In(array);
        }

        public static T[] GetRange<T>(this T[] array, int index, int count)
        {
            var length = array.Length;
            index = MathV.Clamp(index, 0, length);
            count = MathV.Clamp(count, 0, length - index);
            var newArray = new T[count];
            Array.Copy(array, index, newArray, 0, count);
            return newArray;
        }

        public static T[] Insert<T>(this T[] array, int index, T item)
        {
            var length = array.Length;
            index = MathV.Clamp(index, 0, length);
            var newArray = new T[length + 1];
            newArray[index] = item;
            if (index == 0)
            {
                Array.Copy(array, 0, newArray, 1, length);
            }
            else if (index == length)
            {
                Array.Copy(array, 0, newArray, 0, length);
            }
            else
            {
                Array.Copy(array, 0, newArray, 0, index);
                Array.Copy(array, index, newArray, index + 1, length - index);
            }

            return newArray;
        }

        public static T[] InsertRange<T>(this T[] array, int index, T[] collection)
        {
            var length = array.Length;
            var collectionLength = collection.Length;
            var newLength = length + collectionLength;
            index = MathV.Clamp(index, 0, length);
            var newArray = new T[newLength];
            if (index == 0)
            {
                Array.Copy(array, 0, newArray, collectionLength, length);
                Array.Copy(collection, 0, newArray, 0, collectionLength);
            }
            else if (index == length)
            {
                Array.Copy(array, 0, newArray, 0, length);
                Array.Copy(collection, 0, newArray, index, collectionLength);
            }
            else
            {
                Array.Copy(array, 0, newArray, 0, index);
                Array.Copy(collection, 0, newArray, index, collectionLength);
                Array.Copy(array, index, newArray, index + collectionLength, newLength - index - collectionLength);
            }

            return newArray;
        }

        public static T[] Remove<T>(this T[] array, T item)
        {
            var index = Array.IndexOf(array, item);
            return index == -1 ? array : array.RemoveAt(index);
        }

        public static T[] RemoveAt<T>(this T[] array, int index)
        {
            var length = array.Length;
            if (index >= length || index < 0) return array;
            var maxIndex = length - 1;
            var newArray = new T[maxIndex];
            if (index == 0)
            {
                Array.Copy(array, 1, newArray, 0, maxIndex);
            }
            else if (index == maxIndex)
            {
                Array.Copy(array, 0, newArray, 0, maxIndex);
            }
            else
            {
                Array.Copy(array, 0, newArray, 0, index);
                Array.Copy(array, index + 1, newArray, index, maxIndex - index);
            }

            return newArray;
        }

        public static void RemoveRange<T>(this T[] array, int fromIndex, int count)
        {
            Array.Clear(array, fromIndex, count);
        }

        public static void Clear<T>(this T[] array)
        {
            Array.Clear(array, 0, array.Length);
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source) action(item);
        }

        public static void ForEach<T>(this IEnumerable<T> ts, Action<T, int> action)
        {
            var i = 0;
            foreach (var t in ts)
            {
                action(t, i);
                i++;
            }
        }

        public static IEnumerable<TTarget> ForEach<T, TTarget>(this IEnumerable<T> source, Func<T, TTarget> func)
        {
            return ForEach(source, (_, item) => func(item));
        }

        public static IEnumerable<TTarget> ForEach<T, TTarget>(this IEnumerable<T> source, Func<int, T, TTarget> func)
        {
            var i = 0;
            foreach (var item in source) yield return func(i++, item);
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> ts, Func<T, Task> action)
        {
            foreach (var t in ts) await action(t);
        }

        public static async Task ForEachAsync<T>(this IEnumerable<T> ts, Func<T, int, Task> action)
        {
            var i = 0;
            foreach (var t in ts)
            {
                await action(t, i);
                i++;
            }
        }

        public static T TryPeek<T>(this Stack<T> stack) where T : class
        {
            return stack.Count > 0 ? stack.Peek() : default;
        }

        public static string Description(this Enum value)
        {
            var memInfo = value.GetType().GetMember(value.ToString());
            if (!(memInfo.Length > 0)) return value.ToString();
            var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attrs.Length > 0 ? ((DescriptionAttribute)attrs[0]).Description : value.ToString();
        }

        public static IEnumerable<T> MergeInnerEnumerable<T>(this IEnumerable<IEnumerable<T>> @this)
        {
            var listItem = @this.ToList();
            var list = new List<T>();
            foreach (var item in listItem) list.AddRange(item);
            return list;
        }

        public static IEnumerable<T> MergeDistinctInnerEnumerable<T>(this IEnumerable<IEnumerable<T>> @this)
        {
            var listItem = @this.ToList();
            var list = new List<T>();
            return listItem.Aggregate(list, (current, item) => current.Union(item).ToList());
        }

        public static string StripHtml(this string @this)
        {
            var path = new StringBuilder(@this);
            var sb = new StringBuilder();
            var pos = 0;
            while (pos < path.Length)
            {
                var ch = path[pos];
                pos++;
                if (ch == '<')
                    while (pos < path.Length)
                    {
                        ch = path[pos];
                        pos++;
                        if (ch == '>') break;
                        pos = ch switch
                        {
                            '\'' => GetIndexAfterNextSingleQuote(path, pos),
                            '"' => GetIndexAfterNextDoubleQuote(path, pos),
                            _ => pos
                        };
                    }
                else
                    sb.Append(ch);
            }

            return sb.ToString();
        }

        public static string Substring(StringBuilder @this, int startIndex)
        {
            return @this.ToString(startIndex, @this.Length - startIndex);
        }

        public static string Substring(StringBuilder @this, int startIndex, int length)
        {
            return @this.ToString(startIndex, length);
        }

        public static int GetIndexAfterNextSingleQuote(StringBuilder path, int startIndex)
        {
            while (startIndex < path.Length)
            {
                var ch = path[startIndex];
                startIndex++;
                char nextChar;
                switch (ch)
                {
                    case '\\' when startIndex < path.Length &&
                                   ((nextChar = path[startIndex]) == '\\' || nextChar == '\''):
                        startIndex++;
                        break;
                    case '\'':
                        return startIndex;
                }
            }

            return startIndex;
        }

        public static int GetIndexAfterNextDoubleQuote(StringBuilder path, int startIndex)
        {
            while (startIndex < path.Length)
            {
                var ch = path[startIndex];
                startIndex++;
                char nextChar;
                switch (ch)
                {
                    case '\\' when startIndex < path.Length &&
                                   ((nextChar = path[startIndex]) == '\\' || nextChar == '"'):
                        startIndex++;
                        break;
                    case '"':
                        return startIndex;
                }
            }

            return startIndex;
        }

        public static int Pow(this int t, int p)
        {
            return (int)Math.Pow(t, p);
        }

        public static float Pow(this float t, int p)
        {
            return (float)Math.Pow(t, p);
        }

        public static double Pow(this double t, int p)
        {
            return Math.Pow(t, p);
        }

        /// <summary>
        ///     获取长度
        /// </summary>
        public static int Size<T>(this T[] t)
        {
            return t.Length;
        }

        /// <summary>
        ///     获取长度
        /// </summary>
        public static int Size<T>(this List<T> t)
        {
            return t.Count;
        }

        /// <summary>
        ///     获取长度
        /// </summary>
        public static int Size<T>(this IList<T> t)
        {
            return t.Count;
        }

        /// <summary>
        ///     获取长度
        /// </summary>
        public static int Size<T>(this Dictionary<T, T> t)
        {
            return t.Count;
        }

        /// <summary>
        ///     获取长度
        /// </summary>
        public static int Size<T>(this IDictionary<T, T> t)
        {
            return t.Count;
        }

        /// <summary>
        ///     获取长度
        /// </summary>
        public static int Size<T>(this HashSet<T> t)
        {
            return t.Count;
        }

        /// <summary>
        ///     获取长度
        /// </summary>
        public static int Size(this Enum t)
        {
            return Enum.GetValues(t.GetType()).Length;
        }

        /// <summary>
        ///     获取长度
        /// </summary>
        public static int Size(this Type t)
        {
            return t.IsEnum == false ? -1 : Enum.GetValues(t).Length;
        }

        /// <summary>
        ///     判断为空
        /// </summary>
        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        /// <summary>
        ///     判断不为空
        /// </summary>
        public static bool IsNotEmpty<T>(this IEnumerable<T> source)
        {
            return source.Any();
        }

        public static IEnumerable<int> GetSequence(this Func<int, int> func, int count)
        {
            for (var i = 0; i < count; i++) yield return func(i);
        }

        public static bool IsNullableType(this Type type)
        {
            return type is { IsGenericType: true } &&
                   type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static Type GetNonNullableType(this Type type)
        {
            return IsNullableType(type) ? type.GetGenericArguments()[0] : type;
        }

        public static bool IsEnumerableType(this Type enumerableType)
        {
            return FindGenericType(typeof(IEnumerable<>), enumerableType) != null;
        }

        public static Type GetElementType(this Type enumerableType)
        {
            var type = FindGenericType(typeof(IEnumerable<>), enumerableType);
            return type != null ? type.GetGenericArguments()[0] : enumerableType;
        }

        public static bool IsKindOfGeneric(this Type type, Type definition)
        {
            return FindGenericType(definition, type) != null;
        }

        public static Type FindGenericType(this Type definition, Type type)
        {
            while (type != null && type != typeof(object))
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == definition) return type;
                if (definition.IsInterface)
                    foreach (var type2 in type.GetInterfaces())
                    {
                        var type3 = FindGenericType(definition, type2);
                        if (type3 != null) return type3;
                    }

                type = type.BaseType;
            }

            return null;
        }

        /// <summary>
        ///     Enum转List
        /// </summary>
        public static List<Enum> ToList(this Type type)
        {
            return type.IsEnum == false ? default : Enum.GetValues(type).Cast<Enum>().ToList();
        }

        /// <summary>
        ///     获得枚举名称
        /// </summary>
        public static string GetName<T>(this T item) where T : Enum
        {
            return Enum.GetName(typeof(T), item);
        }

        /// <summary>
        ///     获得枚举int
        /// </summary>
        public static int ToInt<T>(this T item) where T : Enum
        {
            return Convert.ToInt32(item);
        }

        /// <summary>
        ///     判断元素是否在指定集合中
        /// </summary>
        public static bool In<T>(this T t, IEnumerable<T> c)
        {
            return c?.Contains(t) ?? false;
        }

        public static bool Inside<T>(this T t, IEnumerable<T> c)
        {
            return c.Any(i => i.Equals(t));
        }

        public static Expression AndAlso(this Expression left, Expression right)
        {
            return Expression.AndAlso(left, right);
        }

        public static Expression Call(this Expression instance, string methodName, params Expression[] arguments)
        {
            return Expression.Call(instance, instance.Type.GetMethod(methodName)!, arguments);
        }

        public static Expression Property(this Expression expression, string propertyName)
        {
            return Expression.Property(expression, propertyName);
        }

        public static Expression GreaterThan(this Expression left, Expression right)
        {
            return Expression.GreaterThan(left, right);
        }

        public static Expression<TDelegate> ToLambda<TDelegate>(this Expression body,
            params ParameterExpression[] parameters)
        {
            return Expression.Lambda<TDelegate>(body, parameters);
        }

        public static string Reverse(this string value)
        {
            var input = value.ToCharArray();
            var output = new char[value.Length];
            var length = input.Length;
            for (var i = 0; i < length; i++)
                output[length - 1 - i] = input[i];
            return new string(output);
        }

        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrEmpty(s);
        }

        public static string FormatWith(this string format, params object[] args)
        {
            return Format(format, args);
        }

        public static bool IsMatch(this string s, string pattern)
        {
            return s != null && Regex.IsMatch(s, pattern);
        }

        public static string Match(this string s, string pattern)
        {
            return s == null ? "" : Regex.Match(s, pattern).Value;
        }

        public static string ToCamel(this string s)
        {
            if (s.IsNullOrEmpty()) return s;
            return s[0].ToString().ToLower() + s[1..];
        }

        public static string ToPascal(this string s)
        {
            if (s.IsNullOrEmpty()) return s;
            return s[0].ToString().ToUpper() + s[1..];
        }

        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static string Or(this string s, string or)
        {
            return !s.IsNullOrWhiteSpace() ? s : or;
        }

        public static string OrEmpty(this string s)
        {
            return s.Or("");
        }

        public static string NullIfEmpty(this string s)
        {
            return !s.IsNullOrEmpty() ? s : null;
        }

        public static string NullIfWhiteSpace(this string s)
        {
            return !s.IsNullOrWhiteSpace() ? s : null;
        }

        public static string HtmlEncode(this string s)
        {
            return WebUtility.HtmlEncode(s);
        }

        public static string HtmlDecode(this string s)
        {
            return WebUtility.HtmlDecode(s);
        }

        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None,
                    TimeSpan.FromMilliseconds(200));

                static string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    var domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (ArgumentException)
            {
                return false;
            }

            return Regex.IsMatch(email,
                @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
        }

        public static string UrlEncode(this string s)
        {
            return WebUtility.UrlEncode(s);
        }

        public static string UrlDecode(this string s)
        {
            return WebUtility.UrlDecode(s);
        }

        public static string StringFormat(this string format, params object[] args)
        {
            var buffer = new StringBuilder(format);
            var i = 0;
            var param = 0;
            var paramMetaToIndexMap = new Dictionary<string, string>();
            while (i < buffer.Length)
            {
                if (buffer[i] == '}')
                {
                    if (i + 1 < buffer.Length && buffer[i + 1] == '}')
                    {
                        i += 2;
                        continue;
                    }

                    break;
                }

                if (buffer[i] != '{')
                {
                    i++;
                    continue;
                }

                if (i + 1 < buffer.Length && buffer[i + 1] == '{')
                {
                    i += 2;
                    continue;
                }

                var start = i;
                while (i < buffer.Length && buffer[i] != '}') i++;
                if (i == buffer.Length) break;
                var end = i;
                var metastart = start + 1;
                var metaend = metastart;
                while (buffer[metaend] != '}' && buffer[metaend] != ':' && buffer[metaend] != ',') metaend++;
                var paramMeta = buffer.ToString(metastart, metaend - metastart).Trim();
                if (!int.TryParse(paramMeta, out _))
                {
                    string paramIndex;
                    if (paramMeta == "")
                    {
                        paramIndex = param.ToString();
                        param++;
                    }
                    else
                    {
                        buffer.Remove(metastart, paramMeta.Length);
                        if (!paramMetaToIndexMap.ContainsKey(paramMeta))
                        {
                            paramMetaToIndexMap[paramMeta] = param.ToString();
                            param++;
                        }

                        paramIndex = paramMetaToIndexMap[paramMeta];
                    }

                    buffer.Insert(metastart, paramIndex);
                    end += -paramMeta.Length + paramIndex.Length;
                }
                else
                {
                    param++;
                }

                i = end + 1;
            }

            var formatConverted = buffer.ToString();
            return Format(formatConverted, args);
        }

        public static bool ToBool(this string value, bool defaultValue)
        {
            return bool.TryParse(value, out var result) ? result : defaultValue;
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key)
        {
            return dictionary.GetValueOrDefault(key, default);
        }

        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key, TValue defaultValue)
        {
            return dictionary.TryGetValue(key, out var value) ? value : defaultValue;
        }

        public static IDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            return new ReadOnlyDictionary<TKey, TValue>(dictionary);
        }

        public static byte[] ToUtf8Bytes(this string s)
        {
            return Encoding.UTF8.GetBytes(s);
        }

        public static string ToUtf8String(this byte[] utf8Bytes)
        {
            return Encoding.UTF8.GetString(utf8Bytes);
        }

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, bool>> predicate,
            bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IQueryable<T> WhereIf<T>(this IQueryable<T> source, Expression<Func<T, int, bool>> predicate,
            bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, bool> predicate, bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, Func<T, int, bool> predicate,
            bool condition)
        {
            return condition ? source.Where(predicate) : source;
        }

        public static bool IsBetween<T>(this T @this, T min, T max) where T : IComparable<T>
        {
            return @this.CompareTo(min) >= 0 && @this.CompareTo(max) <= 0;
        }

        public static bool InInterval(this float @this, Interval<float> interval)
        {
            return interval.Contains(@this);
        }

        public static bool AboveInterval(this float @this, Interval<float> interval)
        {
            return @this > interval.UpperBound;
        }

        public static bool BelowInterval(this float @this, Interval<float> interval)
        {
            return @this < interval.LowerBound;
        }

        public static int CompareToInterval(this float @this, Interval<float> interval)
        {
            if (@this.BelowInterval(interval))
                return -1;
            return @this.AboveInterval(interval) ? 1 : 0;
        }

        public static T Clamp<T>(this T @this, T min, T max) where T : IComparable<T>
        {
            if (min.CompareTo(max) > 0)
                return default;
            if (@this.CompareTo(min) < 0)
                return min;
            return @this.CompareTo(max) > 0 ? max : @this;
        }

        public static float Clamp(this float @this, float min, float max)
        {
            return @this.Clamp<float>(min, max);
        }

        public static double Clamp(this double @this, double min, double max)
        {
            return @this.Clamp<double>(min, max);
        }

        public static int ClampToLowerBound(this int @this, int lowerBound)
        {
            return @this > lowerBound ? @this : lowerBound;
        }

        public static float ClampToLowerBound(this float @this, float lowerBound)
        {
            return @this > lowerBound ? @this : lowerBound;
        }

        public static double ClampToLowerBound(this double @this, double lowerBound)
        {
            return @this > lowerBound ? @this : lowerBound;
        }

        public static int ClampToUpperBound(this int @this, int upperBound)
        {
            return @this < upperBound ? @this : upperBound;
        }

        public static float ClampToUpperBound(this float @this, float upperBound)
        {
            return @this < upperBound ? @this : upperBound;
        }

        public static double ClampToUpperBound(this double val, double upperBound)
        {
            return val < upperBound ? val : upperBound;
        }

        public static int ClampToPositive(this int @this)
        {
            return @this >= 0 ? @this : 0;
        }

        public static float ClampToPositive(this float @this)
        {
            return @this >= 0.0f ? @this : 0.0f;
        }

        public static Interval<float> ClampToPositive(this Interval<float> @this)
        {
            return @this.LowerBound switch
            {
                >= 0f => @this,
                < 0f when @this.UpperBound >= 0f => Interval.Create(0f, @this.UpperBound),
                _ => Interval.Create(0f)
            };
        }

        public static double ClampToPositive(this double @this)
        {
            return @this >= 0.0 ? @this : 0.0;
        }

        public static int ClampToNegative(this int @this)
        {
            return @this <= 0 ? @this : 0;
        }

        public static float ClampToNegative(this float @this)
        {
            return @this <= 0.0f ? @this : 0.0f;
        }

        public static double ClampToNegative(this double @this)
        {
            return @this <= 0.0 ? @this : 0.0;
        }

        public static float Ceil(this float @this)
        {
            return (float)Math.Ceiling(@this);
        }

        public static double Ceil(this double @this)
        {
            return Math.Ceiling(@this);
        }

        public static int CeilToInt(this float @this)
        {
            return (int)Math.Ceiling(@this);
        }

        public static int CeilToInt(this double @this)
        {
            return (int)Math.Ceiling(@this);
        }

        public static float Floor(this float @this)
        {
            return (float)Math.Floor(@this);
        }

        public static double Floor(this double @this)
        {
            return Math.Floor(@this);
        }

        public static int FloorToInt(this float @this)
        {
            return (int)Math.Floor(@this);
        }

        public static int FloorToInt(this double @this)
        {
            return (int)Math.Floor(@this);
        }

        public static float Normalize01(this float @this, float min, float max)
        {
            @this = @this.Clamp<float>(min, max);
            @this -= min;
            var df = max - min;
            if (MathC.AeqZero(df))
                return default;
            return @this / df;
        }

        public static double Normalize01(this double @this, double min, double max)
        {
            @this = @this.Clamp<double>(min, max);
            @this -= min;
            var df = max - min;
            if (MathC.AeqZero(df))
                return default;
            return @this / df;
        }

        public class ArgumentValuePair<TA, TV>
        {
            public TA Argument { get; set; }
            public TV Value { get; set; }
        }
    }

    /// <summary>
    ///     数学函数库G
    /// </summary>
    public static class MathG
    {
        public static readonly float TwoPi = 2.0f * MathV.Pi;
        public static readonly float HalfPi = MathV.Pi / 2.0f;
        public static readonly float ThirdPi = MathV.Pi / 3.0f;
        public static readonly float QuarterPi = MathV.Pi / 4.0f;
        public static readonly float FifthPi = MathV.Pi / 5.0f;
        public static readonly float SixthPi = MathV.Pi / 6.0f;
        public static readonly float Sqrt2 = MathV.Sqrt(2.0f);
        public static readonly float Sqrt2Inv = 1.0f / MathV.Sqrt(2.0f);
        public static readonly float Sqrt3 = MathV.Sqrt(3.0f);
        public static readonly float Sqrt3Inv = 1.0f / MathV.Sqrt(3.0f);
        public static readonly float Epsilon = 1.0e-9f;
        public static readonly float EpsilonComp = 1.0f - Epsilon;
        public static readonly float Rad2Deg = 180.0f / MathV.Pi;
        public static readonly float Deg2Rad = MathV.Pi / 180.0f;
        public static float Pi => MathV.Pi;

        public static float Chebyshev(this ICollection<Utility> @this)
        {
            if (@this.Count == 0)
                return 0.0f;
            var wsum = @this.SumWeights();
            if (MathC.AeqZero(wsum))
                return 0.0f;
            var vlist = new List<float>(@this.Count);
            vlist.AddRange(@this.Select(util => util.Value * (util.Weight / wsum)));
            var ret = vlist.Max<float>();
            return ret;
        }

        public static float WeightedMetrics(this ICollection<Utility> @this, float p = 2.0f)
        {
            if (p < 1.0f)
                return default;
            if (@this.Count == 0)
                return 0.0f;
            var wsum = @this.SumWeights();
            var vlist = new List<float>(@this.Count);
            vlist.AddRange(@this.Select(util => util.Weight / wsum * (float)Math.Pow(util.Value, p)));
            var sum = vlist.Sum();
            var res = (float)Math.Pow(sum, 1 / p);
            return res;
        }

        public static float MultiplyCombined(this ICollection<Utility> @this)
        {
            var count = @this.Count;
            return count == 0 ? 0.0f : @this.Aggregate(1.0f, (current, el) => current * el.Combined);
        }

        public static float MultiplyValues(this ICollection<Utility> @this)
        {
            var count = @this.Count;
            return count == 0 ? 0.0f : @this.Aggregate(1.0f, (current, el) => current * el.Value);
        }

        public static float MultiplyWeights(this ICollection<Utility> @this)
        {
            var count = @this.Count;
            return count == 0 ? 0.0f : @this.Aggregate(1.0f, (current, el) => current * el.Weight);
        }

        public static float SumValues(this ICollection<Utility> @this)
        {
            var count = @this.Count;
            return count == 0 ? 0.0f : @this.Sum(el => el.Value);
        }

        public static float SumWeights(this ICollection<Utility> @this)
        {
            var count = @this.Count;
            return count == 0 ? 0.0f : @this.Sum(el => el.Weight);
        }

        public static float AsinSafe(float x)
        {
            return MathV.Asin(MathV.Clamp(x, -1.0f, 1.0f));
        }

        public static float AcosSafe(float x)
        {
            return MathV.Acos(MathV.Clamp(x, -1.0f, 1.0f));
        }

        public static float CatmullRom(float p0, float p1, float p2, float p3, float t)
        {
            var tt = t * t;
            return
                0.5f
                * (2.0f * p1
                   + (-p0 + p2) * t
                   + (2.0f * p0 - 5.0f * p1 + 4.0f * p2 - p3) * tt
                   + (-p0 + 3.0f * p1 - 3.0f * p2 + p3) * tt * t
                );
        }
    }

    /// <summary>
    ///     计时器
    /// </summary>
    public static class TimeC
    {
        public static readonly Stopwatch Clock;

        static TimeC()
        {
            Clock = new Stopwatch();
            Clock.Start();
        }

        /// <summary>
        ///     秒计时器
        /// </summary>
        public static float TotalSeconds => (float)Clock.Elapsed.TotalSeconds;

        /// <summary>
        ///     毫秒计时器
        /// </summary>
        public static float TotalMilliseconds => (float)Clock.Elapsed.TotalMilliseconds;
    }

    #region Extension

    public enum Comparator
    {
        [Description("==")] Equal,
        [Description("!=")] NotEqual,
        [Description("<")] LessThan,
        [Description(">")] GreaterThan,
        [Description("<=")] LessThanOrEqual,
        [Description(">=")] GreaterThanOrEqual
    }

    public static class Guard
    {
        public static void ArgumentIsRelativePath(string value, string name)
        {
            ArgumentNotNull(value, name);

            if (Path.IsPathRooted(value)) throw new ArgumentException($"The value '{value}' must not be rooted", name);
        }

        public static void ArgumentNotNull(object value, string name)
        {
            if (value != null) return;
            var message = Format(CultureInfo.InvariantCulture, "Failed Null Check on '{0}'", name);
            throw new ArgumentNullException(name, message);
        }

        public static void ArgumentNonNegative(int value, string name)
        {
            if (value > -1) return;
            var message = Format(CultureInfo.InvariantCulture, "The value for '{0}' must be non-negative", name);
            throw new ArgumentException(message, name);
        }

        public static void ArgumentNotEmptyString(string value, string name)
        {
            if (value?.Length > 0) return;
            var message = Format(CultureInfo.InvariantCulture, "The value for '{0}' must not be empty", name);
            throw new ArgumentException(message, name);
        }

        public static void ArgumentInRange(int value, int minValue, string name)
        {
            if (value >= minValue) return;
            var message = Format(CultureInfo.InvariantCulture,
                "The value '{0}' for '{1}' must be greater than or equal to '{2}'",
                value,
                name,
                minValue);
            throw new ArgumentOutOfRangeException(name, message);
        }

        public static void ArgumentInRange(int value, int minValue, int maxValue, string name)
        {
            if (value >= minValue && value <= maxValue) return;
            var message = Format(CultureInfo.InvariantCulture,
                "The value '{0}' for '{1}' must be greater than or equal to '{2}' and less than or equal to '{3}'",
                value,
                name,
                minValue,
                maxValue);
            throw new ArgumentOutOfRangeException(name, message);
        }
    }

    public static class ReflectionExtensions
    {
        public static IEnumerable<Type> GetLoadableTypes(this Assembly assembly)
        {
            Guard.ArgumentNotNull(assembly, nameof(assembly));
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException e)
            {
                return e.Types.Where(t => t != null);
            }
        }

        public static bool HasInterface(this Type type, Type targetInterface)
        {
            Guard.ArgumentNotNull(type, nameof(type));
            Guard.ArgumentNotNull(targetInterface, nameof(targetInterface));
            return targetInterface.IsAssignableFrom(type) || type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == targetInterface);
        }

        public static string GetCustomAttributeValue<T>(this Assembly assembly, string propertyName) where T : Attribute
        {
            Guard.ArgumentNotNull(assembly, nameof(assembly));
            Guard.ArgumentNotEmptyString(propertyName, nameof(propertyName));
            if (assembly == null || IsNullOrEmpty(propertyName)) return Empty;
            var attributes = assembly.GetCustomAttributes(typeof(T), false);
            if (attributes.Length == 0) return Empty;
            if (attributes[0] is not T attribute) return Empty;
            var propertyInfo = attribute.GetType().GetProperty(propertyName);
            if (propertyInfo == null) return Empty;
            var value = propertyInfo.GetValue(attribute, null);
            return value.ToString();
        }

        public static T CreateUninitialized<T>()
        {
            return (T)FormatterServices.GetUninitializedObject(typeof(T));
        }

        public static void Invoke(object obj, string methodName, params object[] parameters)
        {
            var method = obj.GetType().GetMethod(methodName, BindingFlags.Instance | BindingFlags.NonPublic);
            if (method != null) method.Invoke(obj, parameters);
        }
    }

    public static class StringExtensions
    {
        public static NaturalSortComparer WithNaturalSort(this IComparer<string> stringComparer)
        {
            return new NaturalSortComparer(stringComparer);
        }

        public static NaturalSortComparer WithNaturalSort(this StringComparison stringComparison)
        {
            return new NaturalSortComparer(stringComparison);
        }

        public static bool Contains(this string s, string expectedSubstring, StringComparison comparison)
        {
            Guard.ArgumentNotNull(s, nameof(s));
            Guard.ArgumentNotNull(expectedSubstring, nameof(expectedSubstring));
            return s.IndexOf(expectedSubstring, comparison) > -1;
        }

        public static bool ContainsAny(this string s, IEnumerable<char> characters)
        {
            Guard.ArgumentNotNull(s, nameof(s));
            return s.IndexOfAny(characters.ToArray()) > -1;
        }

        public static string DebugRepresentation(this string s)
        {
            s ??= "(null)";
            return Format(CultureInfo.InvariantCulture, "\"{0}\"", s);
        }

        public static string ToNullIfEmpty(this string s)
        {
            return IsNullOrEmpty(s) ? null : s;
        }

        public static bool StartsWith(this string s, char c)
        {
            if (IsNullOrEmpty(s)) return false;
            return s.First() == c;
        }

        public static string RightAfter(this string s, string search)
        {
            Guard.ArgumentNotNull(search, nameof(search));
            if (s == null) return null;
            var lastIndex = s.IndexOf(search, StringComparison.OrdinalIgnoreCase);
            return lastIndex < 0 ? null : s[(lastIndex + search.Length)..];
        }

        public static string RightAfterLast(this string s, string search)
        {
            Guard.ArgumentNotNull(search, nameof(search));
            if (s == null) return null;
            var lastIndex = s.LastIndexOf(search, StringComparison.OrdinalIgnoreCase);
            return lastIndex < 0 ? null : s[(lastIndex + search.Length)..];
        }

        public static string LeftBeforeLast(this string s, string search)
        {
            Guard.ArgumentNotNull(search, nameof(search));
            if (s == null) return null;
            var lastIndex = s.LastIndexOf(search, StringComparison.OrdinalIgnoreCase);
            return lastIndex < 0 ? null : s[..lastIndex];
        }

        public static string ParseFileName(this string path)
        {
            return path?.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar)
                .RightAfterLast(Path.DirectorySeparatorChar + "");
        }

        public static string ParseParentDirectory(this string path)
        {
            return path?.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar)
                .LeftBeforeLast(Path.DirectorySeparatorChar + "");
        }

        public static string EnsureStartsWith(this string s, char c)
        {
            if (s == null) return null;
            return c + s.TrimStart(c);
        }

        public static string EnsureEndsWith(this string s, char c)
        {
            if (s == null) return null;
            return s.TrimEnd(c) + c;
        }

        public static string EnsureValidPath(this string path)
        {
            if (IsNullOrEmpty(path)) return null;
            var components = path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            var result = new StringBuilder();
            foreach (var component in components)
            {
                if (result.Length > 0) result.Append(Path.DirectorySeparatorChar);
                result.Append(CoerceValidFileName(component));
            }

            return result.ToString();
        }

        public static string NormalizePath(this string path)
        {
            return IsNullOrEmpty(path)
                ? null
                : path.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
        }

        public static string TrimEnd(this string s, string suffix)
        {
            Guard.ArgumentNotNull(suffix, nameof(suffix));
            if (s == null) return null;
            return !s.EndsWith(suffix, StringComparison.OrdinalIgnoreCase) ? s : s[..^suffix.Length];
        }

        public static string RemoveSurroundingQuotes(this string s)
        {
            Guard.ArgumentNotNull(s, nameof(s));
            if (s.Length < 2)
                return s;
            var quoteCharacters = new[] { '"', '\'' };
            var firstCharacter = s[0];
            if (!quoteCharacters.Contains(firstCharacter))
                return s;
            return firstCharacter != s[^1] ? s : s[1..^2];
        }

        public static int ToInt32(this string s)
        {
            Guard.ArgumentNotNull(s, nameof(s));
            return int.TryParse(s, out var val) ? val : 0;
        }

        public static string Wrap(this string text, int maxLength = 72)
        {
            Guard.ArgumentNotNull(text, nameof(text));
            if (text.Length == 0) return Empty;
            var sb = new StringBuilder();
            foreach (var unwrappedLine in text.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                var line = new StringBuilder();
                foreach (var word in unwrappedLine.Split(' '))
                {
                    var needsLeadingSpace = line.Length > 0;
                    var extraLength = (needsLeadingSpace ? 1 : 0) + word.Length;
                    if (line.Length + extraLength > maxLength)
                    {
                        sb.AppendLine(line.ToString());
                        line.Clear();
                        needsLeadingSpace = false;
                    }

                    if (needsLeadingSpace)
                        line.Append(" ");
                    line.Append(word);
                }

                sb.AppendLine(line.ToString());
            }

            return sb.ToString();
        }

        public static Uri ToUriSafe(this string url)
        {
            Guard.ArgumentNotNull(url, nameof(url));
            Uri.TryCreate(url, UriKind.Absolute, out var uri);
            return uri;
        }

        public static string Humanize(this string s)
        {
            if (IsNullOrWhiteSpace(s)) return s;
            var matches = Regex.Matches(s, @"[a-zA-Z\d]{1,}", RegexOptions.None);
            if (matches.Count == 0) return s;
            var result = matches.Select(match => match.Value.ToLower(CultureInfo.InvariantCulture));
            var combined = Join(" ", result);
            return char.ToUpper(combined[0], CultureInfo.InvariantCulture) + combined[1..];
        }

        public static string GetSha256Hash(this string input)
        {
            Guard.ArgumentNotNull(input, nameof(input));
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = sha256.ComputeHash(bytes);
            return Join("", hash.Select(b => b.ToString("x2", CultureInfo.InvariantCulture)));
        }

        public static string CoerceValidFileName(string filename)
        {
            var invalidChars = Regex.Escape(new string(Path.GetInvalidFileNameChars()));
            var invalidReStr = Format(CultureInfo.InvariantCulture, @"[{0}]+", invalidChars);
            var reservedWords = new[]
            {
                "CON", "PRN", "AUX", "CLOCK$", "NUL", "COM0", "COM1", "COM2", "COM3", "COM4",
                "COM5", "COM6", "COM7", "COM8", "COM9", "LPT0", "LPT1", "LPT2", "LPT3", "LPT4",
                "LPT5", "LPT6", "LPT7", "LPT8", "LPT9"
            };
            var sanitisedNamePart = Regex.Replace(filename, invalidReStr, "_");
            return reservedWords.Select(reservedWord => Format(CultureInfo.InvariantCulture, "^{0}\\.", reservedWord))
                .Aggregate(sanitisedNamePart,
                    (current, reservedWordPattern) => Regex.Replace(current, reservedWordPattern, "_reservedWord_.",
                        RegexOptions.IgnoreCase));
        }
    }

    public class NaturalSortComparer : IComparer<string>
    {
        private const byte TokenNone = 0;
        private const byte TokenOther = 1;
        private const byte TokenDigits = 2;
        private const byte TokenLetters = 3;
        private readonly IComparer<string> _stringComparer;
        private readonly StringComparison _stringComparison;

        public NaturalSortComparer(StringComparison stringComparison)
        {
            _stringComparison = stringComparison;
        }

        public NaturalSortComparer(IComparer<string> stringComparer)
        {
            _stringComparer = stringComparer;
        }

        public int Compare(string str1, string str2)
        {
            if (str1 == str2) return 0;
            if (str1 == null) return -1;
            if (str2 == null) return 1;
            var strLength1 = str1.Length;
            var strLength2 = str2.Length;
            var startIndex1 = 0;
            var startIndex2 = 0;
            while (true)
            {
                var endIndex1 = startIndex1;
                var token1 = TokenNone;
                while (endIndex1 < strLength1)
                {
                    var charToken = GetTokenFromChar(str1[endIndex1]);
                    if (token1 == TokenNone)
                        token1 = charToken;
                    else if (token1 != charToken) break;
                    endIndex1++;
                }

                var endIndex2 = startIndex2;
                var token2 = TokenNone;
                while (endIndex2 < strLength2)
                {
                    var charToken = GetTokenFromChar(str2[endIndex2]);
                    if (token2 == TokenNone)
                        token2 = charToken;
                    else if (token2 != charToken) break;
                    endIndex2++;
                }

                var tokenCompare = token1.CompareTo(token2);
                if (tokenCompare != 0)
                    return tokenCompare;
                if (token1 == TokenNone)
                    return 0;
                var rangeLength1 = endIndex1 - startIndex1;
                var rangeLength2 = endIndex2 - startIndex2;
                if (token1 == TokenDigits)
                {
                    var maxLength = Math.Max(rangeLength1, rangeLength2);
                    const char paddingChar = '0';
                    var paddingLength1 = maxLength - rangeLength1;
                    var paddingLength2 = maxLength - rangeLength2;
                    for (var i = 0; i < maxLength; i++)
                    {
                        var digit1 = i < paddingLength1 ? paddingChar : str1[startIndex1 + i - paddingLength1];
                        var digit2 = i < paddingLength2 ? paddingChar : str2[startIndex2 + i - paddingLength2];
                        var digitCompare = digit1.CompareTo(digit2);
                        if (digitCompare != 0)
                            return digitCompare;
                    }

                    var paddingCompare = paddingLength1.CompareTo(paddingLength2);
                    if (paddingCompare != 0)
                        return paddingCompare;
                }
                else if (_stringComparer is not null)
                {
                    var tokenString1 = str1.Substring(startIndex1, rangeLength1);
                    var tokenString2 = str2.Substring(startIndex2, rangeLength2);
                    var stringCompare = _stringComparer.Compare(tokenString1, tokenString2);
                    if (stringCompare != 0)
                        return stringCompare;
                }
                else
                {
                    var minLength = Math.Min(rangeLength1, rangeLength2);
                    var stringCompare =
                        string.Compare(str1, startIndex1, str2, startIndex2, minLength, _stringComparison);
                    if (stringCompare == 0) stringCompare = rangeLength1 - rangeLength2;

                    if (stringCompare != 0)
                        return stringCompare;
                }

                startIndex1 = endIndex1;
                startIndex2 = endIndex2;
            }
        }

        private static byte GetTokenFromChar(char c)
        {
            return c >= 'a'
                ? c <= 'z'
                    ? TokenLetters
                    : c < 128
                        ? TokenOther
                        : char.IsLetter(c)
                            ? TokenLetters
                            : TokenOther
                : c >= 'A'
                    ? c <= 'Z'
                        ? TokenLetters
                        : TokenOther
                    : c is >= '0' and <= '9'
                        ? TokenDigits
                        : TokenOther;
        }
    }

    public static class ByteExtensions
    {
        public static byte[] ToBytes(this bool input)
        {
            return BitConverter.GetBytes(input);
        }

        public static byte[] ToBytes(this char input)
        {
            return BitConverter.GetBytes(input);
        }

        public static byte[] ToBytes(this double input)
        {
            return BitConverter.GetBytes(input);
        }

        public static byte[] ToBytes(this short input)
        {
            return BitConverter.GetBytes(input);
        }

        public static byte[] ToBytes(this int input)
        {
            return BitConverter.GetBytes(input);
        }

        public static byte[] ToBytes(this long input)
        {
            return BitConverter.GetBytes(input);
        }

        public static byte[] ToBytes(this ushort input)
        {
            return BitConverter.GetBytes(input);
        }

        public static byte[] ToBytes(this float input)
        {
            return BitConverter.GetBytes(input);
        }

        public static byte[] ToBytes(this uint input)
        {
            return BitConverter.GetBytes(input);
        }

        public static byte[] ToBytes(this ulong input)
        {
            return BitConverter.GetBytes(input);
        }

        public static byte[] ToBytesReversed(this bool input)
        {
            var result = BitConverter.GetBytes(input);
            Array.Reverse(result);
            return result;
        }

        public static byte[] ToBytesReversed(this char input)
        {
            var result = BitConverter.GetBytes(input);
            Array.Reverse(result);
            return result;
        }

        public static byte[] ToBytesReversed(this double input)
        {
            var result = BitConverter.GetBytes(input);
            Array.Reverse(result);
            return result;
        }

        public static byte[] ToBytesReversed(this short input)
        {
            var result = BitConverter.GetBytes(input);
            Array.Reverse(result);
            return result;
        }

        public static byte[] ToBytesReversed(this int input)
        {
            var result = BitConverter.GetBytes(input);
            Array.Reverse(result);
            return result;
        }

        public static byte[] ToBytesReversed(this long input)
        {
            var result = BitConverter.GetBytes(input);
            Array.Reverse(result);
            return result;
        }

        public static byte[] ToBytesReversed(this float input)
        {
            var result = BitConverter.GetBytes(input);
            Array.Reverse(result);
            return result;
        }

        public static byte[] ToBytesReversed(this ushort input)
        {
            var result = BitConverter.GetBytes(input);
            Array.Reverse(result);
            return result;
        }

        public static byte[] ToBytesReversed(this uint input)
        {
            var result = BitConverter.GetBytes(input);
            Array.Reverse(result);
            return result;
        }

        public static byte[] ToBytesReversed(this ulong input)
        {
            var result = BitConverter.GetBytes(input);
            Array.Reverse(result);
            return result;
        }

        public static byte[] ToBytesBigEndian(this int input)
        {
            var result = BitConverter.GetBytes(input);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(result);
            return result;
        }

        public static byte[] ToBytesLittleEndian(this int input)
        {
            var result = BitConverter.GetBytes(input);
            if (!BitConverter.IsLittleEndian)
                Array.Reverse(result);
            return result;
        }

        public static byte[] GetBytesAt(this byte[] input, int at, int n)
        {
            if (input == null || input.Length == 0 || n < 1 || at < 0 || at > input.Length)
                return new byte[] { };
            var resultLength = at + n > input.Length ? input.Length - at : n;
            var result = new byte[resultLength];
            Buffer.BlockCopy(input, at, result, 0, resultLength);
            return result;
        }

        public static byte[] Append(this byte[] input, byte[] newBytes)
        {
            switch (input)
            {
                case null when newBytes == null:
                    return new byte[] { };
                case null:
                    return newBytes;
            }

            if (newBytes == null)
                return input;
            var result = new byte[input.Length + newBytes.Length];
            Array.Copy(input, result, input.Length);
            Array.Copy(newBytes, 0, result, input.Length, newBytes.Length);
            return result;
        }

        public static byte[] Insert(this byte[] input, byte[] newBytes, int at)
        {
            if (input == null && newBytes == null) return null;
            if (input == null || input.Length == 0) return newBytes;
            if (input.Length == 0 && (newBytes == null || newBytes.Length == 0)) return input;
            var tempAt = at > input.Length ? input.Length : at;
            var bytes = new byte[input.Length + newBytes.Length];
            Buffer.BlockCopy(input, 0, bytes, 0, tempAt);
            Buffer.BlockCopy(newBytes, 0, bytes, tempAt, newBytes.Length);
            Buffer.BlockCopy(input, tempAt, bytes, tempAt + newBytes.Length, input.Length - tempAt);
            return bytes;
        }

        public static byte[] Remove(this byte[] input, int at, int n)
        {
            if (input == null) return null;
            if (input.Length == 0) return new byte[] { };
            if (at < 0 || at > input.Length || n < 1) return input;
            byte[] result;
            if (at + n > input.Length)
            {
                var subLength = input.Length - at;
                result = new byte[subLength];
                Buffer.BlockCopy(input, 0, result, 0, subLength);
            }
            else
            {
                result = new byte[input.Length - n];
                Buffer.BlockCopy(input, 0, result, 0, at);
                Buffer.BlockCopy(input, at + n, result, at, input.Length - at - n);
            }

            return result;
        }

        public static string ToHexString(this byte[] input)
        {
            if (input == null || input.Length == 0)
                return Empty;
            return BitConverter.ToString(input);
        }

        public static string ToHexStringDashFree(this byte[] input)
        {
            if (input == null || input.Length == 0)
                return Empty;
            return BitConverter.ToString(input).Replace("-", Empty);
        }

        public static string ToHexStringBase64(this byte[] input)
        {
            if (input == null || input.Length == 0)
                return Empty;
            return Convert.ToBase64String(input);
        }

        public static bool IsBase64(this string input)
        {
            return !IsNullOrEmpty(input)
                   && input.Length % 4 == 0
                   && !input.Contains(" ")
                   && !input.Contains("\t")
                   && !input.Contains("\r")
                   && !input.Contains("\n");
        }

        public static bool IsHexString(this string input)
        {
            return !IsNullOrEmpty(input) && Regex.IsMatch(input, @"\A\b[0-9a-fA-F]+\b\Z");
        }

        public static bool IsHexStringCStyle(this string input)
        {
            return !IsNullOrEmpty(input) && Regex.IsMatch(input, @"\A\b(0[xX])?[0-9a-fA-F]+\b\Z");
        }

        public static byte[] GetBytes(this string input)
        {
            return input.IsBase64()
                ? Convert.FromBase64String(input)
                : new byte[] { };
        }
    }

    #endregion

    #endregion

    #region Core

    /// <summary>
    ///     集合
    /// </summary>
    public static class Collect
    {
        #region Enumerable

        /// <summary>
        ///     平均值
        /// </summary>
        public static float Mean(this IEnumerable<float> @this)
        {
            var sum = 0.0f;
            var count = 0;
            using (var enumerator = @this.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    sum += enumerator.Current;
                    count++;
                }
            }

            return sum / count;
        }

        #endregion

        #region Arrays

        /// <summary>
        ///     复制数组到指定的长度
        /// </summary>
        public static T[] CopyOf<T>(T[] original, int newLength)
        {
            var dest = new T[newLength];
            Array.Copy(original, dest, MathV.Min(original.Length, newLength));
            return dest;
        }

        /// <summary>
        ///     将指定的长度复制到一个新数组中
        /// </summary>
        public static T[] CopyOfRange<T>(T[] original, int fromIndex, int toIndex)
        {
            var length = toIndex - fromIndex;
            var dest = new T[length];
            Array.Copy(original, fromIndex, dest, 0, length);
            return dest;
        }

        /// <summary>
        ///     将数组用指定元素填充
        /// </summary>
        public static void Fill<T>(T[] array, T value)
        {
            for (var i = 0; i < array.Length; ++i) array[i] = value;
        }

        /// <summary>
        ///     将数组用指定范围的元素填充
        /// </summary>
        public static void Fill<T>(T[] array, int fromIndex, int toIndex, T value)
        {
            for (var i = fromIndex; i < toIndex; ++i) array[i] = value;
        }

        /// <summary>
        ///     元素交换
        /// </summary>
        public static void Swap<T>(this T[] arr, int i, int j)
        {
            if (i < arr.Length && j < arr.Length && i >= 0 && j >= 0)
                (arr[i], arr[j]) = (arr[j], arr[i]);
        }

        /// <summary>
        ///     移动指定位数(轮转)
        /// </summary>
        public static void RotateMove<T>(this T[] tempArray, int move)
        {
            var length = tempArray.Length;
            var newArray = new List<T>(tempArray).ToArray();
            var newIndex = length - move % length;
            for (var i = 0; i < length; ++i) tempArray[i] = newArray[(newIndex + i) % length];
        }

        /// <summary>
        ///     获取Id
        /// </summary>
        public static int GetId<T>(this T temp, T[] tempArray)
        {
            var length = tempArray.Length;
            for (var i = 0; i < length; ++i)
                if (tempArray[i].Equals(temp))
                    return i;
            return -1;
        }

        /// <summary>
        ///     获取Id
        /// </summary>
        public static int IndexOf<T>(this T[] @this, T value) where T : IEquatable<T>
        {
            for (var i = 0; i < @this.Length; i++)
                if (@this[i].Equals(value))
                    return i;
            return -1;
        }

        /// <summary>
        ///     哈希去重
        /// </summary>
        public static T[] HashDistinct<T>(this T[] tempArray)
        {
            return HashDistinct(tempArray.ToList()).ToArray();
        }

        #endregion

        #region Lists

        /// <summary>
        ///     复制列表到指定的长度
        /// </summary>
        public static List<T> CopyOf<T>(List<T> original, int newLength)
        {
            return CopyOf(original.ToArray(), newLength).ToList();
        }

        /// <summary>
        ///     将指定的长度复制到一个新列表中
        /// </summary>
        public static List<T> CopyOfRange<T>(List<T> original, int fromIndex, int toIndex)
        {
            return CopyOfRange(original.ToArray(), fromIndex, toIndex).ToList();
        }

        /// <summary>
        ///     将列表用指定元素填充
        /// </summary>
        public static void Fill<T>(List<T> temp, T value)
        {
            for (var i = 0; i < temp.Count; ++i) temp[i] = value;
        }

        /// <summary>
        ///     将列表用指定范围的元素填充
        /// </summary>
        public static void Fill<T>(List<T> temp, int fromIndex, int toIndex, T value)
        {
            for (var i = fromIndex; i < toIndex; ++i) temp[i] = value;
        }

        /// <summary>
        ///     元素交换
        /// </summary>
        public static void Swap<T>(this List<T> tempList, int i, int j)
        {
            if (i < tempList.Count && j < tempList.Count && i >= 0 && j >= 0)
                (tempList[i], tempList[j]) = (tempList[j], tempList[i]);
        }

        /// <summary>
        ///     移动指定位数(轮转)
        /// </summary>
        public static void RotateMove<T>(this List<T> tempList, int move)
        {
            var length = tempList.Count;
            var newList = new List<T>(tempList);
            var newIndex = length - move % length;
            for (var i = 0; i < length; ++i) tempList[i] = newList[(newIndex + i) % length];
        }

        /// <summary>
        ///     获取Id
        /// </summary>
        public static int GetId<T>(this T temp, List<T> tempArray)
        {
            var count = tempArray.Count;
            for (var i = 0; i < count; ++i)
                if (tempArray[i].Equals(temp))
                    return i;
            return -1;
        }

        /// <summary>
        ///     哈希去重
        /// </summary>
        public static List<T> HashDistinct<T>(this List<T> tempList)
        {
            var set = new HashSet<T>();
            var temp = new List<T>();
            foreach (var t in tempList.Where(t => !set.Contains(t)))
            {
                set.Add(t);
                temp.Add(t);
            }

            return temp;
        }

        #endregion

        #region Matrixs

        #region Common

        /// <summary>
        ///     Double单位
        /// </summary>
        public const int DoubleSize = sizeof(double);

        /// <summary>
        ///     行
        /// </summary>
        public static int RowCount<T>(this T[,] mat)
        {
            return mat.GetLength(0);
        }

        /// <summary>
        ///     列
        /// </summary>
        public static int ColumnCount<T>(this T[,] mat)
        {
            return mat.GetLength(1);
        }

        /// <summary>
        ///     交换行
        /// </summary>
        public static void SwapRow<T>(this T[][] x, int i, int j, int nCols)
        {
            int u = i * nCols, v = j * nCols;
            for (var m = 0; m < nCols; m++)
            {
                Swap(x, u, v);
                u++;
                v++;
            }
        }

        /// <summary>
        ///     交换列
        /// </summary>
        public static void SwapColumn<T>(this T[][] x, int i, int j, int nRows, int nCols)
        {
            int u = i, v = j;
            for (var m = 0; m < nRows; m++)
            {
                Swap(x, u, v);
                u += nCols;
                v += nCols;
            }
        }

        /// <summary>
        ///     数组转矩阵
        /// </summary>
        public static T[,] ArrayToMatrix<T>(int nRows, int nCols, T[] elements)
        {
            var count = nRows * nCols;
            if (count != elements.Length)
                return default;
            var mat = new T[nRows, nCols];
            Buffer.BlockCopy(elements, 0, mat, 0, DoubleSize * count);
            return mat;
        }

        /// <summary>
        ///     IEnumerable转矩阵
        /// </summary>
        public static T[,] EnumerableToMatrix<T>(int nRows, int nCols, IEnumerable<T> elements)
        {
            var count = nRows * nCols;
            var m = new T[nRows, nCols];
            using var x = elements.GetEnumerator();
            for (var i = 0; i < count; i++)
            {
                if (!x.MoveNext())
                    return default;
                m[i, i] = x.Current;
            }

            return x.MoveNext() ? default : m;
        }

        /// <summary>
        ///     保存
        /// </summary>
        public static void Save<T>(T[,] mat, string filePath)
        {
            using var sw = new StreamWriter(filePath);
            var m = mat.RowCount();
            var n = mat.ColumnCount() - 1;
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    sw.Write(mat[i, j]);
                    sw.Write('\t');
                }

                sw.WriteLine(mat[i, n]);
            }
        }

        /// <summary>
        ///     读取
        /// </summary>
        public static T[,] Load<T>(string filePath, Encoding encoding)
        {
            using var sr = new StreamReader(filePath, encoding);
            var arr = sr.ReadLine()?.Split('\t', ',');
            if (arr == null) return default;
            var cols = arr.Length;
            var list = new List<T>();
            if (list == null) throw new ArgumentNullException(nameof(list));
            var rows = 1;
            while (sr.Peek() != -1)
            {
                var line = sr.ReadLine();
                if (IsNullOrWhiteSpace(line)) continue;
                arr = line.Split('\t', ',');
                if (arr.Length != cols) return default;
                rows++;
            }

            return EnumerableToMatrix(rows, cols, list);
        }

        /// <summary>
        ///     矩阵转字符串
        /// </summary>
        public static string MatrixToString<T>(T[,] mat)
        {
            var m = mat.RowCount();
            var n = mat.ColumnCount() - 1;
            var s = new StringBuilder();
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    s.Append(mat[i, j]);
                    s.Append("\t");
                }

                s.AppendLine(mat[i, n].ToString());
            }

            return s.ToString();
        }

        /// <summary>
        ///     复制矩阵
        /// </summary>
        public static T[,] CopyMatrix<T>(T[,] mat)
        {
            var newMatrix = new T[mat.RowCount(), mat.ColumnCount()];
            Array.Copy(mat, newMatrix, mat.Length);
            return newMatrix;
        }

        /// <summary>
        ///     复制Vector
        /// </summary>
        public static T[] CopyVector<T>(T[] vector)
        {
            var newVector = new T[vector.Length];
            Array.Copy(vector, newVector, vector.Length);
            return newVector;
        }

        /// <summary>
        ///     转置矩阵
        /// </summary>
        public static T[,] Transpose<T>(T[,] a)
        {
            var nRows = a.RowCount();
            var nCols = a.ColumnCount();
            var result = new T[nCols, nRows];
            for (var i = 0; i < nRows; i++)
                for (var j = 0; j < nCols; j++)
                    result[i, j * nRows + i] = result[i, i * nCols + j];
            return result;
        }

        #endregion

        #region Subset & Special

        /// <summary>
        ///     Double基本矩阵
        /// </summary>
        public static double[,] Mat;

        /// <summary>
        ///     单位矩阵
        /// </summary>
        public static T[,] Ones<T>(int nRows, int nCols)
        {
            var mat = new T[nRows, nCols];
            for (var i = nRows * nCols - 1; i >= 0; i--)
                mat[i, i] = default;
            return mat;
        }

        /// <summary>
        ///     单位小矩阵
        /// </summary>
        public static T[,] Eye<T>(int nRows, int nCols)
        {
            var n = MathV.Min(nRows, nCols);
            var mat = new T[nRows, nCols];
            for (var i = 0; i < n; i++)
                mat[i, i] = default;
            return mat;
        }

        /// <summary>
        ///     行
        /// </summary>
        public static IEnumerable<double> GetRow(int index)
        {
            var nCols = Mat.ColumnCount();
            for (var j = 0; j < nCols; j++)
                yield return Mat[index, j];
        }

        /// <summary>
        ///     列
        /// </summary>
        public static IEnumerable<double> GetColumn(int index)
        {
            var nRows = Mat.RowCount();
            for (var i = 0; i < nRows; i++)
                yield return Mat[i, index];
        }

        /// <summary>
        ///     对角线
        /// </summary>
        public static IEnumerable<double> GetDiagonal(bool mainDiagonal = true)
        {
            var n = Math.Min(Mat.RowCount(), Mat.ColumnCount());
            if (mainDiagonal)
            {
                for (var i = 0; i < n; i++)
                    yield return Mat[i, i];
            }
            else
            {
                var nCols = Mat.ColumnCount();
                for (var i = 0; i < n; i++)
                    yield return Mat[i, nCols - i - 1];
            }
        }

        /// <summary>
        ///     行
        /// </summary>
        public static void SetRow(int index, IEnumerable<double> data)
        {
            var nCols = Mat.ColumnCount();
            using var x = data.GetEnumerator();
            for (var j = 0; j < nCols; j++)
            {
                if (!x.MoveNext()) throw new ArgumentOutOfRangeException();
                Mat[index, j] = x.Current;
            }

            if (x.MoveNext()) throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        ///     列
        /// </summary>
        public static void SetColumn(int index, IEnumerable<double> data)
        {
            var nRows = Mat.RowCount();
            using var x = data.GetEnumerator();
            for (var i = 0; i < nRows; i++)
            {
                if (!x.MoveNext()) throw new ArgumentOutOfRangeException();
                Mat[i, index] = x.Current;
            }

            if (x.MoveNext()) throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        ///     对角线
        /// </summary>
        public static void SetDiagonal(IEnumerable<double> data, bool mainDiagonal = true)
        {
            var n = Math.Min(Mat.RowCount(), Mat.ColumnCount());
            var nCols = Mat.ColumnCount();
            using var x = data.GetEnumerator();
            for (var i = 0; i < n; i++)
            {
                if (!x.MoveNext()) throw new ArgumentOutOfRangeException();
                if (mainDiagonal) Mat[i, i] = x.Current;
                else Mat[i, nCols - i - 1] = x.Current;
            }

            if (x.MoveNext()) throw new ArgumentOutOfRangeException();
        }

        #endregion

        #region Scalar

        /// <summary>
        ///     增加
        /// </summary>
        public static double[,] AddScalar(double[,] mat, double scalar)
        {
            int m = mat.RowCount(), n = mat.ColumnCount();
            var result = new double[m, n];
            for (var i = m * n - 1; i >= 0; i--)
                result[i, i] = mat[i, i] + scalar;
            return result;
        }

        /// <summary>
        ///     增加
        /// </summary>
        public static double[,] AddScalar(double scalar, double[,] mat)
        {
            return AddScalar(mat, scalar);
        }

        /// <summary>
        ///     减少
        /// </summary>
        public static double[,] SubtractScalar(double[,] mat, double scalar)
        {
            int m = mat.RowCount(), n = mat.ColumnCount();
            var result = new double[m, n];
            for (var i = m * n - 1; i >= 0; i--)
                result[i, i] = mat[i, i] - scalar;
            return result;
        }

        /// <summary>
        ///     减少
        /// </summary>
        public static double[,] SubtractScalar(double scalar, double[,] mat)
        {
            int m = mat.RowCount(), n = mat.ColumnCount();
            var result = new double[m, n];
            for (var i = m * n - 1; i >= 0; i--)
                result[i, i] = scalar - mat[i, i];
            return result;
        }

        /// <summary>
        ///     乘
        /// </summary>
        public static double[,] MultiplyScalar(double[,] mat, double scalar)
        {
            int m = mat.RowCount(), n = mat.ColumnCount();
            var result = new double[m, n];
            for (var i = m * n - 1; i >= 0; i--)
                result[i, i] = mat[i, i] * scalar;
            return result;
        }

        /// <summary>
        ///     乘
        /// </summary>
        public static double[,] MultiplyScalar(double scalar, double[,] mat)
        {
            return MultiplyScalar(mat, scalar);
        }

        /// <summary>
        ///     划分
        /// </summary>
        public static double[,] DivideScalar(double[,] mat, double scalar)
        {
            return MultiplyScalar(mat, 1.0 / scalar);
        }

        /// <summary>
        ///     划分
        /// </summary>
        public static double[,] DivideScalar(double scalar, double[,] inverseMat)
        {
            return MultiplyScalar(scalar, inverseMat);
        }

        #endregion

        #endregion

        #region Dictionary

        /// <summary>
        ///     读取值
        /// </summary>
        public static T Value<TKey, T>(this Dictionary<TKey, T> @this, TKey key)
        {
            return @this.TryGetValue(key, out var obj) ? obj : default;
        }

        /// <summary>
        ///     移除所有
        /// </summary>
        public static int RemoveAll<TKey, TValue>(this IDictionary<TKey, TValue> @this, Predicate<TKey> match)
        {
            if (@this == null ||
                match == null)
                return 0;
            var keysToRemove = @this.Keys.Where(k => match(k)).ToList();
            if (keysToRemove.Count <= 0) return keysToRemove.Count;
            foreach (var key in keysToRemove)
                @this.Remove(key);
            return keysToRemove.Count;
        }

        /// <summary>
        ///     尝试添加
        /// </summary>
        public static Dictionary<TKey, TValue> TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key,
            TValue value)
        {
            if (dict.ContainsKey(key) == false) dict.Add(key, value);
            return dict;
        }

        /// <summary>
        ///     添加或替换
        /// </summary>
        public static Dictionary<TKey, TValue> AddOrReplace<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key,
            TValue value)
        {
            dict[key] = value;
            return dict;
        }

        /// <summary>
        ///     获取值
        /// </summary>
        public static TValue GetValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TKey key,
            TValue defaultValue = default)
        {
            return dict.ContainsKey(key) ? dict[key] : defaultValue;
        }

        /// <summary>
        ///     判断字典中是否存在符合条件的键值对
        /// </summary>
        public static bool Exists<TKey, TValue>(this IDictionary<TKey, TValue> source,
            Func<TKey, TValue, bool> predicate)
        {
            return source.Any(kv => predicate(kv.Key, kv.Value));
        }

        #endregion

        #region ReadWriteLock

        public static IDisposable Read(this ReaderWriterLockSlim @this)
        {
            return new ReadLockToken(@this);
        }

        public static IDisposable Write(this ReaderWriterLockSlim @this)
        {
            return new WriteLockToken(@this);
        }

        public sealed class ReadLockToken : IDisposable
        {
            public ReaderWriterLockSlim Sync;

            public ReadLockToken(ReaderWriterLockSlim sync)
            {
                Sync = sync;
                sync.EnterReadLock();
            }

            public void Dispose()
            {
                if (Sync == null) return;
                Sync.ExitReadLock();
                Sync = null;
            }
        }

        public sealed class WriteLockToken : IDisposable
        {
            public ReaderWriterLockSlim Sync;

            public WriteLockToken(ReaderWriterLockSlim sync)
            {
                Sync = sync;
                sync.EnterWriteLock();
            }

            public void Dispose()
            {
                if (Sync == null) return;
                Sync.ExitWriteLock();
                Sync = null;
            }
        }

        #endregion
    }

    /// <summary>
    ///     哈希表
    /// </summary>
    public static class HashMap
    {
        public static HashSet<KeyValuePair<TKey, TValue>> SetOfKeyValuePairs<TKey, TValue>(
            this IDictionary<TKey, TValue> dictionary)
        {
            var entries = new HashSet<KeyValuePair<TKey, TValue>>();
            foreach (var keyValuePair in dictionary) entries.Add(keyValuePair);
            return entries;
        }

        public static TValue GetValueOrNull<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            dictionary.TryGetValue(key, out var ret);
            return ret;
        }

        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key,
            TValue defaultValue)
        {
            return dictionary.TryGetValue(key, out var ret) ? ret : defaultValue;
        }

        public static void PutAll<TKey, TValue>(this IDictionary<TKey, TValue> d1, IDictionary<TKey, TValue> d2)
        {
            if (d2 is null) return;
            foreach (var key in d2.Keys)
                d1[key] = d2[key];
        }
    }

    /// <summary>
    ///     文件夹工具
    /// </summary>
    public static class FileTools
    {
        public static void IndexNext(ref int pIndex, int pMin, int pMax)
        {
            pIndex += 1;
            if (pIndex > pMax)
                pIndex = pMin;
        }

        public static string FormatToUnityPath(string path)
        {
            return path.Replace("\\", "/");
        }

        public static string FormatToSysFilePath(string path)
        {
            return path.Replace("/", "\\");
        }

        public static string GetFileExtension(string path)
        {
            return Path.GetExtension(path).ToLower();
        }

        public static string[] GetSpecifyFilesInFolder(string path, string[] extensions = null, bool exclude = false)
        {
            if (IsNullOrEmpty(path)) return null;
            if (extensions == null)
                return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            if (exclude)
                return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
                    .Where(f => !extensions.Contains(GetFileExtension(f))).ToArray();
            return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
                .Where(f => extensions.Contains(GetFileExtension(f))).ToArray();
        }

        public static string[] GetSpecifyFilesInFolder(string path, string pattern)
        {
            return IsNullOrEmpty(path) ? null : Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
        }

        public static string[] GetAllFilesInFolder(string path)
        {
            return GetSpecifyFilesInFolder(path);
        }

        public static string[] GetAllDirsInFolder(string path)
        {
            return Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
        }

        public static List<string> GetAllFilesName(string path, List<string> fileList)
        {
            var dir = new DirectoryInfo(path);
            var fil = dir.GetFiles();
            var dii = dir.GetDirectories();
            fileList.AddRange(from f in fil where !f.FullName.EndsWith(".meta") select f.Name);
            foreach (var d in dii) GetAllFilesName(d.FullName, fileList);
            return fileList;
        }

        public static void CheckFileAndCreateDirWhenNeeded(string filePath)
        {
            if (IsNullOrEmpty(filePath)) return;

            var fileInfo = new FileInfo(filePath);
            var dirInfo = fileInfo.Directory ?? throw new ArgumentNullException("fileI" + "nfo.Directory");
            if (!dirInfo.Exists) Directory.CreateDirectory(dirInfo.FullName);
        }

        public static void CheckDirAndCreateWhenNeeded(string folderPath)
        {
            if (IsNullOrEmpty(folderPath)) return;
            if (!Directory.Exists(folderPath)) Directory.CreateDirectory(folderPath);
        }

        public static bool SafeWriteAllBytes(string outFile, byte[] outBytes)
        {
            try
            {
                if (IsNullOrEmpty(outFile)) return false;
                CheckFileAndCreateDirWhenNeeded(outFile);
                if (File.Exists(outFile)) File.SetAttributes(outFile, FileAttributes.Normal);
                File.WriteAllBytes(outFile, outBytes);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SafeWriteAllLines(string outFile, string[] outLines)
        {
            try
            {
                if (IsNullOrEmpty(outFile)) return false;
                CheckFileAndCreateDirWhenNeeded(outFile);
                if (File.Exists(outFile)) File.SetAttributes(outFile, FileAttributes.Normal);
                File.WriteAllLines(outFile, outLines);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SafeWriteAllText(string outFile, string text)
        {
            try
            {
                if (IsNullOrEmpty(outFile)) return false;
                CheckFileAndCreateDirWhenNeeded(outFile);
                if (File.Exists(outFile)) File.SetAttributes(outFile, FileAttributes.Normal);
                File.WriteAllText(outFile, text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static byte[] SafeReadAllBytes(string inFile)
        {
            try
            {
                if (IsNullOrEmpty(inFile)) return null;
                if (!File.Exists(inFile)) return null;
                File.SetAttributes(inFile, FileAttributes.Normal);
                return File.ReadAllBytes(inFile);
            }
            catch
            {
                return null;
            }
        }

        public static string[] SafeReadAllLines(string inFile)
        {
            try
            {
                if (IsNullOrEmpty(inFile)) return null;
                if (!File.Exists(inFile)) return null;
                File.SetAttributes(inFile, FileAttributes.Normal);
                return File.ReadAllLines(inFile);
            }
            catch
            {
                return null;
            }
        }

        public static string SafeReadAllText(string inFile)
        {
            try
            {
                if (IsNullOrEmpty(inFile)) return null;
                if (!File.Exists(inFile)) return null;
                File.SetAttributes(inFile, FileAttributes.Normal);
                return File.ReadAllText(inFile);
            }
            catch
            {
                return null;
            }
        }

        public static void DeleteDirectory(string dirPath)
        {
            if (!Directory.Exists(dirPath)) return;
            var files = Directory.GetFiles(dirPath);
            var dirs = Directory.GetDirectories(dirPath);
            foreach (var file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (var dir in dirs) DeleteDirectory(dir);
            Directory.Delete(dirPath, false);
        }

        public static bool SafeClearDir(string folderPath)
        {
            try
            {
                if (IsNullOrEmpty(folderPath)) return true;
                if (Directory.Exists(folderPath)) DeleteDirectory(folderPath);
                Directory.CreateDirectory(folderPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SafeDeleteDir(string folderPath)
        {
            try
            {
                if (IsNullOrEmpty(folderPath)) return true;
                if (Directory.Exists(folderPath)) DeleteDirectory(folderPath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SafeDeleteFile(string filePath)
        {
            try
            {
                if (IsNullOrEmpty(filePath)) return true;
                if (!File.Exists(filePath)) return true;
                File.SetAttributes(filePath, FileAttributes.Normal);
                File.Delete(filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SafeRenameFile(string sourceFileName, string destFileName)
        {
            try
            {
                if (IsNullOrEmpty(sourceFileName)) return false;
                if (!File.Exists(sourceFileName)) return true;
                SafeDeleteFile(destFileName);
                File.SetAttributes(sourceFileName, FileAttributes.Normal);
                File.Move(sourceFileName, destFileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool SafeCopyFile(string fromFile, string toFile)
        {
            try
            {
                if (IsNullOrEmpty(fromFile)) return false;
                if (!File.Exists(fromFile)) return false;
                CheckFileAndCreateDirWhenNeeded(toFile);
                SafeDeleteFile(toFile);
                File.Copy(fromFile, toFile, true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static byte[] Encypt(byte[] targetData, byte key)
        {
            var result = new byte[targetData.Length];
            var dataLength = targetData.Length;
            for (var i = 0; i < dataLength; ++i) result[i] = (byte)(targetData[i] ^ key);
            return result;
        }
    }

    #endregion

    #region Extend

    #region EventMonitor

    public enum EventType //事件码（类型）
    {
    }

    #region CallBacks

    public delegate void CallBack();

    public delegate void CallBack<in T>(T arg);

    public delegate void CallBack<in T, in TX>(T arg1, TX arg2);

    public delegate void CallBack<in T, in TX, in TY>(T arg1, TX arg2, TY arg3);

    public delegate void CallBack<in T, in TX, in TY, in TZ>(T arg1, TX arg2, TY arg3, TZ arg4);

    public delegate void CallBack<in T, in TX, in TY, in TZ, in TW>(T arg1, TX arg2, TY arg3, TZ arg4, TW arg5);

    #endregion

    /// <summary>
    ///     事件中心 (广播)
    /// </summary>
    public static class EventCenter
    {
        #region Center

        /// <summary>
        ///     事件表
        /// </summary>
        public static readonly Dictionary<EventType, Delegate> EventTable = new();

        /// <summary>
        ///     添加时
        /// </summary>
        public static void OnListenerAdding(EventType eventType, Delegate callBack)
        {
            if (!EventTable.ContainsKey(eventType)) EventTable.Add(eventType, null);
            var d = EventTable[eventType];
            if (d != null && d.GetType() != callBack.GetType())
                throw new Exception(
                    $"尝试为事件{eventType}添加不同类型的委托，当前事件所对应的委托是{d.GetType()}，要添加的委托类型为{callBack.GetType()}");
        }

        /// <summary>
        ///     移除时
        /// </summary>
        public static void OnListenerRemoving(EventType eventType, Delegate callBack)
        {
            if (EventTable.ContainsKey(eventType))
            {
                var d = EventTable[eventType];
                if (d == null)
                    throw new Exception($"移除监听错误：事件{eventType}没有对应的委托");
                if (d.GetType() != callBack.GetType())
                    throw new Exception(
                        $"移除监听错误：尝试为事件{eventType}移除不同类型的委托，当前委托类型为{d.GetType()}，要移除的委托类型为{callBack.GetType()}");
            }
            else
            {
                throw new Exception($"移除监听错误：没有事件码{eventType}");
            }
        }

        /// <summary>
        ///     移除后
        /// </summary>
        public static void OnListenerRemoved(EventType eventType)
        {
            if (EventTable[eventType] == null) EventTable.Remove(eventType);
        }

        #endregion

        #region AddListener

        //0变量
        public static void AddListener(EventType eventType, CallBack callBack)
        {
            OnListenerAdding(eventType, callBack);
            EventTable[eventType] = (CallBack)EventTable[eventType] + callBack;
        }

        //1变量
        public static void AddListener<T>(EventType eventType, CallBack<T> callBack)
        {
            OnListenerAdding(eventType, callBack);
            EventTable[eventType] = (CallBack<T>)EventTable[eventType] + callBack;
        }

        //2变量
        public static void AddListener<T, TX>(EventType eventType, CallBack<T, TX> callBack)
        {
            OnListenerAdding(eventType, callBack);
            EventTable[eventType] = (CallBack<T, TX>)EventTable[eventType] + callBack;
        }

        //3变量
        public static void AddListener<T, TX, TY>(EventType eventType, CallBack<T, TX, TY> callBack)
        {
            OnListenerAdding(eventType, callBack);
            EventTable[eventType] = (CallBack<T, TX, TY>)EventTable[eventType] + callBack;
        }

        //4变量
        public static void AddListener<T, TX, TY, TZ>(EventType eventType, CallBack<T, TX, TY, TZ> callBack)
        {
            OnListenerAdding(eventType, callBack);
            EventTable[eventType] = (CallBack<T, TX, TY, TZ>)EventTable[eventType] + callBack;
        }

        //5变量
        public static void AddListener<T, TX, TY, TZ, TW>(EventType eventType, CallBack<T, TX, TY, TZ, TW> callBack)
        {
            OnListenerAdding(eventType, callBack);
            EventTable[eventType] = (CallBack<T, TX, TY, TZ, TW>)EventTable[eventType] + callBack;
        }

        #endregion

        #region RemoveListener

        //0变量
        public static void RemoveListener(EventType eventType, CallBack callBack)
        {
            OnListenerRemoving(eventType, callBack);
            EventTable[eventType] = (CallBack)EventTable[eventType] - callBack;
            OnListenerRemoved(eventType);
        }

        //1变量
        public static void RemoveListener<T>(EventType eventType, CallBack<T> callBack)
        {
            OnListenerRemoving(eventType, callBack);
            EventTable[eventType] = (CallBack<T>)EventTable[eventType] - callBack;
            OnListenerRemoved(eventType);
        }

        //2变量
        public static void RemoveListener<T, TX>(EventType eventType, CallBack<T, TX> callBack)
        {
            OnListenerRemoving(eventType, callBack);
            EventTable[eventType] = (CallBack<T, TX>)EventTable[eventType] - callBack;
            OnListenerRemoved(eventType);
        }

        //3变量
        public static void RemoveListener<T, TX, TY>(EventType eventType, CallBack<T, TX, TY> callBack)
        {
            OnListenerRemoving(eventType, callBack);
            EventTable[eventType] = (CallBack<T, TX, TY>)EventTable[eventType] - callBack;
            OnListenerRemoved(eventType);
        }

        //4变量
        public static void RemoveListener<T, TX, TY, TZ>(EventType eventType, CallBack<T, TX, TY, TZ> callBack)
        {
            OnListenerRemoving(eventType, callBack);
            EventTable[eventType] = (CallBack<T, TX, TY, TZ>)EventTable[eventType] - callBack;
            OnListenerRemoved(eventType);
        }

        //5变量
        public static void RemoveListener<T, TX, TY, TZ, TW>(EventType eventType, CallBack<T, TX, TY, TZ, TW> callBack)
        {
            OnListenerRemoving(eventType, callBack);
            EventTable[eventType] = (CallBack<T, TX, TY, TZ, TW>)EventTable[eventType] - callBack;
            OnListenerRemoved(eventType);
        }

        #endregion

        #region Broadcast

        //0变量
        public static void Broadcast(EventType eventType)
        {
            if (!EventTable.TryGetValue(eventType, out var d)) return;

            if (d is CallBack callBack)
                callBack();
            else
                throw new Exception($"广播事件错误：事件{eventType}对应委托具有不同的类型");
        }

        //1变量
        public static void Broadcast<T>(EventType eventType, T arg)
        {
            if (!EventTable.TryGetValue(eventType, out var d)) return;

            if (d is CallBack<T> callBack)
                callBack(arg);
            else
                throw new Exception($"广播事件错误：事件{eventType}对应委托具有不同的类型");
        }

        //2变量
        public static void Broadcast<T, TX>(EventType eventType, T arg1, TX arg2)
        {
            if (!EventTable.TryGetValue(eventType, out var d)) return;
            if (d is CallBack<T, TX> callBack)
                callBack(arg1, arg2);
            else
                throw new Exception($"广播事件错误：事件{eventType}对应委托具有不同的类型");
        }

        //3变量
        public static void Broadcast<T, TX, TY>(EventType eventType, T arg1, TX arg2, TY arg3)
        {
            if (!EventTable.TryGetValue(eventType, out var d)) return;
            if (d is CallBack<T, TX, TY> callBack)
                callBack(arg1, arg2, arg3);
            else
                throw new Exception($"广播事件错误：事件{eventType}对应委托具有不同的类型");
        }

        //4变量
        public static void Broadcast<T, TX, TY, TZ>(EventType eventType, T arg1, TX arg2, TY arg3, TZ arg4)
        {
            if (!EventTable.TryGetValue(eventType, out var d)) return;
            if (d is CallBack<T, TX, TY, TZ> callBack)
                callBack(arg1, arg2, arg3, arg4);
            else
                throw new Exception($"广播事件错误：事件{eventType}对应委托具有不同的类型");
        }

        //5变量
        public static void Broadcast<T, TX, TY, TZ, TW>(EventType eventType, T arg1, TX arg2, TY arg3, TZ arg4, TW arg5)
        {
            if (!EventTable.TryGetValue(eventType, out var d)) return;
            if (d is CallBack<T, TX, TY, TZ, TW> callBack)
                callBack(arg1, arg2, arg3, arg4, arg5);
            else
                throw new Exception($"广播事件错误：事件{eventType}对应委托具有不同的类型");
        }

        #endregion
    }

    #endregion

    #region EventManager

    /// <summary>
    ///     事件接口
    /// </summary>
    public interface IEventData
    {
    }

    /// <summary>
    ///     事件管理器
    /// </summary>
    public static class EventManager
    {
        /// <summary>
        ///     事件表
        /// </summary>
        public static readonly Dictionary<string, IEventData> EventDict = new();

        #region Add

        /// <summary>
        ///     0
        /// </summary>
        public static void AddEventListener(string type, Action action)
        {
            if (EventDict.ContainsKey(type))
                ((EventData)EventDict[type]).ActionList += action;
            else
                EventDict.Add(type, new EventData(action));
        }

        /// <summary>
        ///     1
        /// </summary>
        public static void AddEventListener<T>(string type, Action<T> action)
        {
            if (EventDict.ContainsKey(type))
                ((EventData<T>)EventDict[type]).ActionList += action;
            else
                EventDict.Add(type, new EventData<T>(action));
        }

        /// <summary>
        ///     2
        /// </summary>
        public static void AddEventListener<T1, T2>(string type, Action<T1, T2> action)
        {
            if (EventDict.ContainsKey(type))
                ((EventData<T1, T2>)EventDict[type]).ActionList += action;
            else
                EventDict.Add(type, new EventData<T1, T2>(action));
        }

        #endregion

        #region Remove

        /// <summary>
        ///     0
        /// </summary>
        public static void RemoveEventListener(string type, Action action)
        {
            if (EventDict.ContainsKey(type)) ((EventData)EventDict[type]).ActionList -= action;
        }

        /// <summary>
        ///     1
        /// </summary>
        public static void RemoveEventListener<T>(string type, Action<T> action)
        {
            if (EventDict.ContainsKey(type)) ((EventData<T>)EventDict[type]).ActionList -= action;
        }

        /// <summary>
        ///     2
        /// </summary>
        public static void RemoveEventListener<T1, T2>(string type, Action<T1, T2> action)
        {
            if (EventDict.ContainsKey(type)) ((EventData<T1, T2>)EventDict[type]).ActionList -= action;
        }

        #endregion

        #region Trigger

        /// <summary>
        ///     0
        /// </summary>
        public static void OnEventTrigger(string type)
        {
            if (EventDict.ContainsKey(type)) ((EventData)EventDict[type]).ActionList?.Invoke();
        }

        /// <summary>
        ///     1
        /// </summary>
        public static void OnEventTrigger<T>(string type, T data)
        {
            if (EventDict.ContainsKey(type)) ((EventData<T>)EventDict[type]).ActionList?.Invoke(data);
        }

        /// <summary>
        ///     2
        /// </summary>
        public static void OnEventTrigger<T1, T2>(string type, T1 data1, T2 data2)
        {
            if (EventDict.ContainsKey(type)) ((EventData<T1, T2>)EventDict[type]).ActionList?.Invoke(data1, data2);
        }

        #endregion
    }

    /// <summary>
    ///     0
    /// </summary>
    public class EventData : IEventData
    {
        public Action ActionList;

        public EventData(Action action)
        {
            ActionList += action;
        }
    }

    /// <summary>
    ///     1
    /// </summary>
    public class EventData<T> : IEventData
    {
        public Action<T> ActionList;

        public EventData(Action<T> action)
        {
            ActionList += action;
        }
    }

    /// <summary>
    ///     2
    /// </summary>
    public class EventData<T1, T2> : IEventData
    {
        public Action<T1, T2> ActionList;

        public EventData(Action<T1, T2> action)
        {
            ActionList += action;
        }
    }

    #endregion

    #region ExcelManager

    public static class ExcelManager
    {
        public const string Extra = ".xlsx";

        public static void Writer(string excelPath, string sheetName, Action<ExcelWorksheet> callback)
        {
            var fileInfo = new FileInfo(excelPath + Extra);
            using var excelPackage = new ExcelPackage(fileInfo);
            if (!File.Exists(excelPath + Extra)) return;
            if (excelPackage.Workbook.Worksheets[sheetName] == null) return;
            var sheet = excelPackage.Workbook.Worksheets[sheetName];
            callback?.Invoke(sheet);
            excelPackage.Save();
        }

        public static ExcelWorksheet Reader(string excelPath, string sheetName)
        {
            var fileInfo = new FileInfo(excelPath + Extra);
            using var excelPackage = new ExcelPackage(fileInfo);
            if (!File.Exists(excelPath + Extra)) return default;
            if (excelPackage.Workbook.Worksheets[sheetName] == null) return default;
            var sheet = excelPackage.Workbook.Worksheets[sheetName];
            return sheet;
        }

        public static void Create(string excelPath, string sheetName)
        {
            var fileInfo = new FileInfo(excelPath + Extra);
            using var excelPackage = new ExcelPackage(fileInfo);
            if (!File.Exists(excelPath + Extra))
            {
                excelPackage.Workbook.Worksheets.Add(sheetName);
                excelPackage.Save();
            }
            else if (excelPackage.Workbook.Worksheets[sheetName] == null)
            {
                excelPackage.Workbook.Worksheets.Add(sheetName);
                excelPackage.Save();
            }
        }

        public static void Delete(string excelPath, string sheetName)
        {
            var fileInfo = new FileInfo(excelPath + Extra);
            using var excelPackage = new ExcelPackage(fileInfo);
            if (!File.Exists(excelPath + Extra)) return;
            if (excelPackage.Workbook.Worksheets[sheetName] == null) return;
            if (excelPackage.Workbook.Worksheets.Count <= 1) return;
            excelPackage.Workbook.Worksheets.Delete(sheetName);
            excelPackage.Save();
        }
    }

    #endregion

    #region StreamManager

    public static class Defaults
    {
        public static int DefaultBufferSizeOnRead { get; } = 1024;
        public static int DefaultBufferSizeOnWrite { get; } = 1024;
    }

    public static partial class StreamExtensions
    {
        public static T ReadAndDeserializeFromJson<T>(
            this Stream stream,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            return ReadAndDeserializeFromJson<T>(stream, new UTF8Encoding(), true,
                Defaults.DefaultBufferSizeOnRead, false, jsonSerializerSettings);
        }

        public static T ReadAndDeserializeFromJson<T>(
            this Stream stream,
            Encoding encoding,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            return ReadAndDeserializeFromJson<T>(stream, encoding, true,
                Defaults.DefaultBufferSizeOnRead, false, jsonSerializerSettings);
        }

        public static T ReadAndDeserializeFromJson<T>(
            this Stream stream,
            bool detectEncodingFromByteOrderMarks,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            return ReadAndDeserializeFromJson<T>(stream, new UTF8Encoding(),
                detectEncodingFromByteOrderMarks, Defaults.DefaultBufferSizeOnRead, false, jsonSerializerSettings);
        }

        public static T ReadAndDeserializeFromJson<T>(
            this Stream stream,
            Encoding encoding,
            bool detectEncodingFromByteOrderMarks,
            int bufferSize,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            return ReadAndDeserializeFromJson<T>(stream, encoding,
                detectEncodingFromByteOrderMarks, bufferSize, false, jsonSerializerSettings);
        }

        public static T ReadAndDeserializeFromJson<T>(
            this Stream stream,
            Encoding encoding,
            bool detectEncodingFromByteOrderMarks,
            int bufferSize,
            bool leaveOpen,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (!stream.CanRead) throw new NotSupportedException("Can't read from this stream.");
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));
            using var streamReader =
                new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen);
            using var jsonTextReader = new JsonTextReader(streamReader);
            var jsonSerializer = jsonSerializerSettings == default
                ? JsonSerializer.Create()
                : JsonSerializer.Create(jsonSerializerSettings);
            return jsonSerializer.Deserialize<T>(jsonTextReader);
        }

        public static object ReadAndDeserializeFromJson(
            this Stream stream,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            return ReadAndDeserializeFromJson(stream, new UTF8Encoding(), true,
                Defaults.DefaultBufferSizeOnRead, jsonSerializerSettings);
        }

        public static object ReadAndDeserializeFromJson(
            this Stream stream,
            Encoding encoding,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            return ReadAndDeserializeFromJson(stream, encoding, true,
                Defaults.DefaultBufferSizeOnRead, false, jsonSerializerSettings);
        }

        public static object ReadAndDeserializeFromJson(
            this Stream stream,
            bool detectEncodingFromByteOrderMarks,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            return ReadAndDeserializeFromJson(stream, new UTF8Encoding(),
                detectEncodingFromByteOrderMarks, Defaults.DefaultBufferSizeOnRead, false, jsonSerializerSettings);
        }

        public static object ReadAndDeserializeFromJson(
            this Stream stream,
            Encoding encoding,
            bool detectEncodingFromByteOrderMarks,
            int bufferSize,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            return ReadAndDeserializeFromJson(stream, encoding,
                detectEncodingFromByteOrderMarks, bufferSize, false, jsonSerializerSettings);
        }

        public static object ReadAndDeserializeFromJson(
            this Stream stream,
            Encoding encoding,
            bool detectEncodingFromByteOrderMarks,
            int bufferSize,
            bool leaveOpen,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (!stream.CanRead) throw new NotSupportedException("Can't read from this stream.");

            if (encoding == null) throw new ArgumentNullException(nameof(encoding));
            using var streamReader =
                new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen);
            using var jsonTextReader = new JsonTextReader(streamReader);
            var jsonSerializer = jsonSerializerSettings == default
                ? JsonSerializer.Create()
                : JsonSerializer.Create(jsonSerializerSettings);
            return jsonSerializer.Deserialize(jsonTextReader);
        }

        public static void SerializeToJsonAndWrite<T>(
            this Stream stream,
            T objectToWrite,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            SerializeToJsonAndWrite(stream, objectToWrite, new UTF8Encoding(), Defaults.DefaultBufferSizeOnWrite, false,
                false, jsonSerializerSettings);
        }

        public static void SerializeToJsonAndWrite<T>(
            this Stream stream,
            T objectToWrite,
            Encoding encoding,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            SerializeToJsonAndWrite(stream, objectToWrite, encoding, Defaults.DefaultBufferSizeOnWrite, false, false,
                jsonSerializerSettings);
        }

        public static void SerializeToJsonAndWrite<T>(
            this Stream stream,
            T objectToWrite,
            Encoding encoding,
            int bufferSize,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            SerializeToJsonAndWrite(stream, objectToWrite, encoding, bufferSize, false, false, jsonSerializerSettings);
        }

        public static void SerializeToJsonAndWrite<T>(
            this Stream stream,
            T objectToWrite,
            Encoding encoding,
            int bufferSize,
            bool leaveOpen,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            SerializeToJsonAndWrite(stream, objectToWrite, encoding, bufferSize, leaveOpen, false,
                jsonSerializerSettings);
        }

        public static void SerializeToJsonAndWrite<T>(
            this Stream stream,
            T objectToWrite,
            bool resetStream,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            SerializeToJsonAndWrite(stream, objectToWrite, new UTF8Encoding(), Defaults.DefaultBufferSizeOnWrite, false,
                resetStream, jsonSerializerSettings);
        }

        public static void SerializeToJsonAndWrite<T>(
            this Stream stream,
            T objectToWrite,
            Encoding encoding,
            bool resetStream, JsonSerializerSettings jsonSerializerSettings = default)
        {
            SerializeToJsonAndWrite(stream, objectToWrite, encoding, Defaults.DefaultBufferSizeOnWrite, false,
                resetStream, jsonSerializerSettings);
        }

        public static void SerializeToJsonAndWrite<T>(
            this Stream stream,
            T objectToWrite,
            Encoding encoding,
            int bufferSize,
            bool leaveOpen,
            bool resetStream,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (!stream.CanWrite) throw new NotSupportedException("Can't write to this stream.");
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));
            using var streamWriter = new StreamWriter(stream, encoding, bufferSize, leaveOpen);
            using var jsonTextWriter = new JsonTextWriter(streamWriter);
            var jsonSerializer = jsonSerializerSettings == default
                ? JsonSerializer.Create()
                : JsonSerializer.Create(jsonSerializerSettings);
            jsonSerializer.Serialize(jsonTextWriter, objectToWrite);
            jsonTextWriter.Flush();
            if (resetStream && stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
        }

        public static void SerializeToJsonAndWrite(
            this Stream stream,
            object objectToWrite,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            SerializeToJsonAndWrite(stream, objectToWrite, new UTF8Encoding(), Defaults.DefaultBufferSizeOnWrite, false,
                false, jsonSerializerSettings);
        }

        public static void SerializeToJsonAndWrite(
            this Stream stream,
            object objectToWrite,
            Encoding encoding,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            SerializeToJsonAndWrite(stream, objectToWrite, encoding, Defaults.DefaultBufferSizeOnWrite, false, false,
                jsonSerializerSettings);
        }

        public static void SerializeToJsonAndWrite(
            this Stream stream,
            object objectToWrite,
            Encoding encoding,
            int bufferSize,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            SerializeToJsonAndWrite(stream, objectToWrite, encoding, bufferSize, false, false, jsonSerializerSettings);
        }

        public static void SerializeToJsonAndWrite(
            this Stream stream,
            object objectToWrite,
            Encoding encoding,
            int bufferSize,
            bool leaveOpen,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            SerializeToJsonAndWrite(stream, objectToWrite, encoding, bufferSize, leaveOpen, false,
                jsonSerializerSettings);
        }

        public static void SerializeToJsonAndWrite(
            this Stream stream,
            object objectToWrite,
            bool resetStream,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            SerializeToJsonAndWrite(stream, objectToWrite, new UTF8Encoding(), Defaults.DefaultBufferSizeOnWrite, false,
                resetStream, jsonSerializerSettings);
        }

        public static void SerializeToJsonAndWrite(
            this Stream stream,
            object objectToWrite,
            Encoding encoding,
            bool resetStream,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            SerializeToJsonAndWrite(stream, objectToWrite, encoding, Defaults.DefaultBufferSizeOnWrite, false,
                resetStream, jsonSerializerSettings);
        }

        public static void SerializeToJsonAndWrite(
            this Stream stream,
            object objectToWrite,
            Encoding encoding,
            int bufferSize,
            bool leaveOpen,
            bool resetStream,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (!stream.CanWrite) throw new NotSupportedException("不能写入");
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));
            using var streamWriter = new StreamWriter(stream, encoding, bufferSize, leaveOpen);

            using var jsonTextWriter = new JsonTextWriter(streamWriter);

            var jsonSerializer = jsonSerializerSettings == null
                ? JsonSerializer.Create()
                : JsonSerializer.Create(jsonSerializerSettings);
            jsonSerializer.Serialize(jsonTextWriter, objectToWrite);
            jsonTextWriter.Flush();
            if (resetStream && stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
        }
    }

    public static partial class StreamExtensions
    {
        public static async Task<T> ReadAndDeserializeFromJsonAsync<T>(
            this Stream stream)
        {
            return await ReadAndDeserializeFromJsonAsync<T>(stream, new UTF8Encoding(), true,
                Defaults.DefaultBufferSizeOnRead, false);
        }

        public static async Task<T> ReadAndDeserializeFromJsonAsync<T>(
            this Stream stream,
            Encoding encoding)
        {
            return await ReadAndDeserializeFromJsonAsync<T>(stream, encoding, true,
                Defaults.DefaultBufferSizeOnRead, false);
        }

        public static async Task<T> ReadAndDeserializeFromJsonAsync<T>(
            this Stream stream,
            bool detectEncodingFromByteOrderMarks)
        {
            return await ReadAndDeserializeFromJsonAsync<T>(stream, new UTF8Encoding(),
                detectEncodingFromByteOrderMarks, Defaults.DefaultBufferSizeOnRead, false);
        }

        public static async Task<T> ReadAndDeserializeFromJsonAsync<T>(
            this Stream stream,
            Encoding encoding,
            bool detectEncodingFromByteOrderMarks,
            int bufferSize)
        {
            return await ReadAndDeserializeFromJsonAsync<T>(stream, encoding,
                detectEncodingFromByteOrderMarks, bufferSize, false);
        }

        public static async Task<T> ReadAndDeserializeFromJsonAsync<T>(
            this Stream stream,
            Encoding encoding,
            bool detectEncodingFromByteOrderMarks,
            int bufferSize,
            bool leaveOpen)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (!stream.CanRead) throw new NotSupportedException("Can't read from this stream.");
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));
            using var streamReader =
                new StreamReader(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen);
            using var jsonTextReader = new JsonTextReader(streamReader);
            var jToken = await JToken.LoadAsync(jsonTextReader);
            return jToken.ToObject<T>();
        }

        public static async Task SerializeToJsonAndWriteAsync<T>(
            this Stream stream,
            T objectToWrite,
            CancellationToken cancellationToken = default,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            await SerializeToJsonAndWriteAsync(stream, objectToWrite, new UTF8Encoding(),
                Defaults.DefaultBufferSizeOnWrite, false, false, cancellationToken, jsonSerializerSettings);
        }

        public static async Task SerializeToJsonAndWriteAsync<T>(
            this Stream stream,
            T objectToWrite,
            Encoding encoding,
            CancellationToken cancellationToken = default,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            await SerializeToJsonAndWriteAsync(stream, objectToWrite, encoding, Defaults.DefaultBufferSizeOnWrite,
                false, false, cancellationToken, jsonSerializerSettings);
        }

        public static async Task SerializeToJsonAndWriteAsync<T>(
            this Stream stream,
            T objectToWrite,
            Encoding encoding,
            int bufferSize,
            CancellationToken cancellationToken = default,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            await SerializeToJsonAndWriteAsync(stream, objectToWrite, encoding, bufferSize, false, false,
                cancellationToken, jsonSerializerSettings);
        }

        public static async Task SerializeToJsonAndWriteAsync<T>(
            this Stream stream,
            T objectToWrite,
            Encoding encoding,
            int bufferSize,
            bool leaveOpen,
            CancellationToken cancellationToken = default,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            await SerializeToJsonAndWriteAsync(stream, objectToWrite, encoding, bufferSize, leaveOpen, false,
                cancellationToken, jsonSerializerSettings);
        }

        public static async Task SerializeToJsonAndWriteAsync<T>(
            this Stream stream,
            T objectToWrite,
            bool resetStream,
            CancellationToken cancellationToken = default,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            await SerializeToJsonAndWriteAsync(stream, objectToWrite, new UTF8Encoding(),
                Defaults.DefaultBufferSizeOnWrite, false, resetStream, cancellationToken, jsonSerializerSettings);
        }

        public static async Task SerializeToJsonAndWriteAsync<T>(
            this Stream stream,
            T objectToWrite,
            Encoding encoding,
            bool resetStream,
            CancellationToken cancellationToken = default,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            await SerializeToJsonAndWriteAsync(stream, objectToWrite, encoding, Defaults.DefaultBufferSizeOnWrite,
                false, resetStream, cancellationToken, jsonSerializerSettings);
        }

        public static async Task SerializeToJsonAndWriteAsync<T>(
            this Stream stream,
            T objectToWrite,
            Encoding encoding,
            int bufferSize,
            bool leaveOpen,
            bool resetStream,
            CancellationToken cancellationToken = default,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (!stream.CanWrite) throw new NotSupportedException("Can't write to this stream.");
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));

            await using var streamWriter = new StreamWriter(stream, encoding, bufferSize, leaveOpen);
            using var jsonTextWriter = new JsonTextWriter(streamWriter);
            var jsonSerializer = jsonSerializerSettings == default
                ? JsonSerializer.Create()
                : JsonSerializer.Create(jsonSerializerSettings);
            jsonSerializer.Serialize(jsonTextWriter, objectToWrite);
            await jsonTextWriter.FlushAsync(cancellationToken);
            if (resetStream && stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
        }

        public static async Task SerializeToJsonAndWriteAsync(
            this Stream stream,
            object objectToWrite,
            CancellationToken cancellationToken = default,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            await SerializeToJsonAndWriteAsync(stream, objectToWrite, new UTF8Encoding(),
                Defaults.DefaultBufferSizeOnWrite, false, false, cancellationToken, jsonSerializerSettings);
        }

        public static async Task SerializeToJsonAndWriteAsync(
            this Stream stream,
            object objectToWrite,
            Encoding encoding,
            CancellationToken cancellationToken = default,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            await SerializeToJsonAndWriteAsync(stream, objectToWrite, encoding, Defaults.DefaultBufferSizeOnWrite,
                false, false, cancellationToken, jsonSerializerSettings);
        }

        public static async Task SerializeToJsonAndWriteAsync(
            this Stream stream,
            object objectToWrite,
            Encoding encoding,
            int bufferSize,
            CancellationToken cancellationToken = default,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            await SerializeToJsonAndWriteAsync(stream, objectToWrite, encoding, bufferSize, false, false,
                cancellationToken, jsonSerializerSettings);
        }

        public static async Task SerializeToJsonAndWriteAsync(
            this Stream stream,
            object objectToWrite,
            Encoding encoding,
            int bufferSize,
            bool leaveOpen,
            CancellationToken cancellationToken = default,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            await SerializeToJsonAndWriteAsync(stream, objectToWrite, encoding, bufferSize, leaveOpen, false,
                cancellationToken, jsonSerializerSettings);
        }

        public static async Task SerializeToJsonAndWriteAsync(
            this Stream stream,
            object objectToWrite,
            bool resetStream,
            CancellationToken cancellationToken = default,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            await SerializeToJsonAndWriteAsync(stream, objectToWrite, new UTF8Encoding(),
                Defaults.DefaultBufferSizeOnWrite, false, resetStream, cancellationToken, jsonSerializerSettings);
        }

        public static async Task SerializeToJsonAndWriteAsync(
            this Stream stream,
            object objectToWrite,
            Encoding encoding,
            bool resetStream,
            CancellationToken cancellationToken = default,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            await SerializeToJsonAndWriteAsync(stream, objectToWrite, encoding, Defaults.DefaultBufferSizeOnWrite,
                false, resetStream, cancellationToken, jsonSerializerSettings);
        }

        public static async Task SerializeToJsonAndWriteAsync(
            this Stream stream,
            object objectToWrite,
            Encoding encoding,
            int bufferSize,
            bool leaveOpen,
            bool resetStream,
            CancellationToken cancellationToken = default,
            JsonSerializerSettings jsonSerializerSettings = default)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (!stream.CanWrite) throw new NotSupportedException("Can't write to this stream.");
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));
            await using var streamWriter = new StreamWriter(stream, encoding, bufferSize, leaveOpen);
            using var jsonTextWriter = new JsonTextWriter(streamWriter);
            var jsonSerializer = jsonSerializerSettings == default
                ? JsonSerializer.Create()
                : JsonSerializer.Create(jsonSerializerSettings);
            jsonSerializer.Serialize(jsonTextWriter, objectToWrite);
            await jsonTextWriter.FlushAsync(cancellationToken);
            if (resetStream && stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);
        }
    }

    public static class ResponseMessageExtensionsAsync
    {
        public static async Task<T> DeserializeAsStreamAsync<T>(
            this HttpResponseMessage message)
        {
            return await DeserializeAsStreamAsync<T>(
                message,
                new UTF8Encoding(),
                true,
                Defaults.DefaultBufferSizeOnRead,
                false);
        }

        public static async Task<T> DeserializeAsStreamAsync<T>(
            this HttpResponseMessage message,
            Encoding encoding)
        {
            return await DeserializeAsStreamAsync<T>(
                message,
                encoding,
                true,
                Defaults.DefaultBufferSizeOnRead,
                false);
        }

        public static async Task<T> DeserializeAsStreamAsync<T>(
            this HttpResponseMessage message,
            bool detectEncodingFromByteOrderMarks)
        {
            return await DeserializeAsStreamAsync<T>(
                message,
                new UTF8Encoding(),
                detectEncodingFromByteOrderMarks,
                Defaults.DefaultBufferSizeOnRead,
                false);
        }

        public static async Task<T> DeserializeAsStreamAsync<T>(
            this HttpResponseMessage message,
            Encoding encoding,
            bool detectEncodingFromByteOrderMarks,
            int bufferSize)
        {
            return await DeserializeAsStreamAsync<T>(
                message,
                encoding,
                detectEncodingFromByteOrderMarks,
                bufferSize,
                false);
        }

        public static async Task<T> DeserializeAsStreamAsync<T>(
            this HttpResponseMessage message,
            Encoding encoding,
            bool detectEncodingFromByteOrderMarks,
            int bufferSize,
            bool leaveOpen)
        {
            var stream = await message.Content.ReadAsStreamAsync();
            return await stream.ReadAndDeserializeFromJsonAsync<T>(
                encoding,
                detectEncodingFromByteOrderMarks,
                bufferSize,
                leaveOpen);
        }
    }

    #endregion

    #endregion

    #region Editor

    public static class BerlinNoise
    {
        public static int[] Perm =
        {
            151, 160, 137, 91, 90, 15,
            131, 13, 201, 95, 96, 53, 194, 233, 7, 225, 140, 36, 103, 30, 69, 142, 8, 99, 37, 240, 21, 10, 23,
            190, 6, 148, 247, 120, 234, 75, 0, 26, 197, 62, 94, 252, 219, 203, 117, 35, 11, 32, 57, 177, 33,
            88, 237, 149, 56, 87, 174, 20, 125, 136, 171, 168, 68, 175, 74, 165, 71, 134, 139, 48, 27, 166,
            77, 146, 158, 231, 83, 111, 229, 122, 60, 211, 133, 230, 220, 105, 92, 41, 55, 46, 245, 40, 244,
            102, 143, 54, 65, 25, 63, 161, 1, 216, 80, 73, 209, 76, 132, 187, 208, 89, 18, 169, 200, 196,
            135, 130, 116, 188, 159, 86, 164, 100, 109, 198, 173, 186, 3, 64, 52, 217, 226, 250, 124, 123,
            5, 202, 38, 147, 118, 126, 255, 82, 85, 212, 207, 206, 59, 227, 47, 16, 58, 17, 182, 189, 28, 42,
            223, 183, 170, 213, 119, 248, 152, 2, 44, 154, 163, 70, 221, 153, 101, 155, 167, 43, 172, 9,
            129, 22, 39, 253, 19, 98, 108, 110, 79, 113, 224, 232, 178, 185, 112, 104, 218, 246, 97, 228,
            251, 34, 242, 193, 238, 210, 144, 12, 191, 179, 162, 241, 81, 51, 145, 235, 249, 14, 239, 107,
            49, 192, 214, 31, 181, 199, 106, 157, 184, 84, 204, 176, 115, 121, 50, 45, 127, 4, 150, 254,
            138, 236, 205, 93, 222, 114, 67, 29, 24, 72, 243, 141, 128, 195, 78, 66, 215, 61, 156, 180,
            151
        };

        public static float Noise(float x)
        {
            var i = MathV.FloorToInt(x) & 0xff;
            x -= MathV.Floor(x);
            return Lerp(Fade(x), Grad(i, x), Grad(i + 1, x - 1));
        }

        public static float Noise(float x, float y)
        {
            var i = MathV.FloorToInt(x) & 0xff;
            var floorToInt = MathV.FloorToInt(y) & 0xff;
            x -= MathV.Floor(x);
            y -= MathV.Floor(y);
            var u = Fade(x);
            var v = Fade(y);
            var a = (Perm[i] + floorToInt) & 0xff;
            var b = (Perm[i + 1] + floorToInt) & 0xff;
            return Lerp(v, Lerp(u, Grad(a, x, y), Grad(b, x - 1, y)),
                Lerp(u, Grad(a + 1, x, y - 1), Grad(b + 1, x - 1, y - 1)));
        }

        public static float Noise(float x, float y, float z)
        {
            var i = MathV.FloorToInt(x) & 0xff;
            var floorToInt = MathV.FloorToInt(y) & 0xff;
            var toInt = MathV.FloorToInt(z) & 0xff;
            x -= MathV.Floor(x);
            y -= MathV.Floor(y);
            z -= MathV.Floor(z);
            var u = Fade(x);
            var v = Fade(y);
            var w = Fade(z);
            var a = (Perm[i] + floorToInt) & 0xff;
            var b = (Perm[i + 1] + floorToInt) & 0xff;
            var aa = (Perm[a] + toInt) & 0xff;
            var ba = (Perm[b] + toInt) & 0xff;
            var ab = (Perm[a + 1] + toInt) & 0xff;
            var bb = (Perm[b + 1] + toInt) & 0xff;
            return Lerp(w, Lerp(v, Lerp(u, Grad(aa, x, y, z), Grad(ba, x - 1, y, z)),
                    Lerp(u, Grad(ab, x, y - 1, z), Grad(bb, x - 1, y - 1, z))),
                Lerp(v, Lerp(u, Grad(aa + 1, x, y, z - 1), Grad(ba + 1, x - 1, y, z - 1)),
                    Lerp(u, Grad(ab + 1, x, y - 1, z - 1), Grad(bb + 1, x - 1, y - 1, z - 1))));
        }

        public static float Fbm(float x, int octave)
        {
            var f = 0.0f;
            var w = 0.5f;
            for (var i = 0; i < octave; i++)
            {
                f += w * Noise(x);
                x *= 2.0f;
                w *= 0.5f;
            }

            return f;
        }

        public static float Fade(float t)
        {
            return t * t * t * (t * (t * 6 - 15) + 10);
        }

        public static float Lerp(float t, float a, float b)
        {
            return MathV.Lerp(a, b, t);
        }

        public static float Grad(int i, float x)
        {
            return (Perm[i] & 1) != 0 ? x : -x;
        }

        public static float Grad(int i, float x, float y)
        {
            var h = Perm[i];
            return ((h & 1) != 0 ? x : -x) + ((h & 2) != 0 ? y : -y);
        }

        public static float Grad(int i, float x, float y, float z)
        {
            var h = Perm[i] & 15;
            var u = h < 8 ? x : y;
            var v = h < 4 ? y : h is 12 or 14 ? x : z;
            return ((h & 1) != 0 ? u : -u) + ((h & 2) != 0 ? v : -v);
        }
    }

    public static class Patcher
    {
        public static long FindJumpInstructionAddress(string filePath, byte[] regionToFind, long jumpInstructionOffset)
        {
            using var b = new BinaryReader(File.Open(filePath, FileMode.Open));
            var length = b.BaseStream.Length;
            long index = 0;
            long firstAdd = -1;
            for (long i = 0; i < length; i++)
            {
                var currentByte = b.ReadByte();
                if (currentByte == regionToFind[index] || (regionToFind[index] == 0x00 && index > 0))
                {
                    if (index == 0)
                        firstAdd = i;
                    index++;
                }
                else
                {
                    index = 0;
                }

                if (index >= regionToFind.LongLength)
                    return firstAdd + jumpInstructionOffset;
            }

            return -1;
        }

        public static byte ReadByteAtAddress(string filePath, long address)
        {
            using var b = new BinaryReader(File.Open(filePath, FileMode.Open));
            b.BaseStream.Seek(address, SeekOrigin.Begin);
            return b.ReadByte();
        }

        public static void WriteByteToAddress(string filePath, byte byteToWrite, long address)
        {
            using Stream stream = File.Open(filePath, FileMode.Open);
            stream.Position = address;
            stream.WriteByte(byteToWrite);
        }

        public static string GetUnityPathFromRegistry()
        {
            var path = Empty;
            return path.EndsWith("Unity.exe") ? path : null;
        }

        public static string GetUnityPathFromArgs()
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && !IsNullOrWhiteSpace(args[1]) && File.Exists(args[1]))
                return args[1];
            return null;
        }

        public static string GetUnityPathFromLocalDirection()
        {
            return File.Exists("Unity.exe") ? Path.GetFullPath("Unity.exe") : null;
        }

        public static void CreateFileBackUp(string filePath)
        {
            File.Copy(filePath, $"{filePath}.bak{DateTime.Now:yyyymmdd_HHmmss}");
        }
    }

    public static class PredicateExtensions
    {
        public static Expression<Func<T, bool>> Begin<T>(bool value = false)
        {
            if (value)
                return parameter => true;
            return parameter => false;
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            return CombineLambdas(left, right, ExpressionType.AndAlso);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right)
        {
            return CombineLambdas(left, right, ExpressionType.OrElse);
        }


        public static Expression<Func<T, bool>> CombineLambdas<T>(this Expression<Func<T, bool>> left,
            Expression<Func<T, bool>> right, ExpressionType expressionType)
        {
            if (IsExpressionBodyConstant(left))
                return right;
            var p = left.Parameters[0];
            var visitor = new SubstituteParameterVisitor
            {
                Sub =
                {
                    [right.Parameters[0]] = p
                }
            };

            Expression body = Expression.MakeBinary(expressionType, left.Body, visitor.Visit(right.Body)!);
            return Expression.Lambda<Func<T, bool>>(body, p);
        }

        public static bool IsExpressionBodyConstant<T>(Expression<Func<T, bool>> left)
        {
            return left.Body.NodeType == ExpressionType.Constant;
        }

        public class SubstituteParameterVisitor : ExpressionVisitor
        {
            public Dictionary<Expression, Expression> Sub = new();

            protected override Expression VisitParameter(ParameterExpression node)
            {
                return Sub.TryGetValue(node, out var newValue) ? newValue : node;
            }
        }
    }

    public static class PrimitiveExtensions
    {
        public static readonly ConcurrentDictionary<Type, List<PropertyInfo>> MemoryObjects = new();

        public static bool IsPropertyACollection(this PropertyInfo property)
        {
            return IsGenericEnumerable(property.PropertyType) || property.PropertyType.IsArray;
        }

        public static bool IsPropertyObject(this PropertyInfo property, object value)
        {
            return Convert.GetTypeCode(property.GetValue(value, null)) == TypeCode.Object;
        }

        private static bool IsGenericEnumerable(Type type)
        {
            return type.IsGenericType &&
                   type.GetInterfaces().Any(
                       ti => ti == typeof(IEnumerable<>) || ti.Name == "IEnumerable");
        }


        internal static List<PropertyInfo> GetAllProperties(this Type type)
        {
            if (MemoryObjects.ContainsKey(type))
                return MemoryObjects[type];

            var properties = type.GetProperties().ToList();
            MemoryObjects.TryAdd(type, properties);
            return properties;
        }

        internal static PropertyInfo GetProperty(Type type, string name)
        {
            return type
                .GetAllProperties()
                .FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        internal static PropertyInfo GetProperty<TEntity>(string name)
        {
            return typeof(TEntity)
                .GetAllProperties()
                .FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public static bool HasProperty(this Type type, string propertyName)
        {
            return type.GetAllProperties().Any(a => a.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));
        }

        public static string[] Fields(this string fields)
        {
            return fields.Split(',');
        }

        public static string FieldName(this string field)
        {
            return field.StartsWith("-", "+") ? field[1..].Trim() : field.Trim();
        }

        public static bool StartsWith(this string text, params string[] with)
        {
            return with.Any(text.StartsWith);
        }

        public static bool IsDescending(this string field)
        {
            return field.StartsWith("-");
        }
    }

    public static class Window
    {
        public static double[] Hamming(int width)
        {
            const double a = 0.53836;
            const double b = -0.46164;

            var phaseStep = 2.0 * Math.PI / (width - 1.0);

            var w = new double[width];
            for (var i = 0; i < w.Length; i++) w[i] = a + b * Math.Cos(i * phaseStep);
            return w;
        }

        public static double[] HammingPeriodic(int width)
        {
            const double a = 0.53836;
            const double b = -0.46164;

            var phaseStep = 2.0 * Math.PI / width;

            var w = new double[width];
            for (var i = 0; i < w.Length; i++) w[i] = a + b * Math.Cos(i * phaseStep);
            return w;
        }

        public static double[] Hann(int width)
        {
            var phaseStep = 2.0 * Math.PI / (width - 1.0);

            var w = new double[width];
            for (var i = 0; i < w.Length; i++) w[i] = 0.5 - 0.5 * Math.Cos(i * phaseStep);
            return w;
        }

        public static double[] HannPeriodic(int width)
        {
            var phaseStep = 2.0 * Math.PI / width;

            var w = new double[width];
            for (var i = 0; i < w.Length; i++) w[i] = 0.5 - 0.5 * Math.Cos(i * phaseStep);
            return w;
        }

        public static double[] Cosine(int width)
        {
            var phaseStep = Math.PI / (width - 1.0);

            var w = new double[width];
            for (var i = 0; i < w.Length; i++) w[i] = Math.Sin(i * phaseStep);
            return w;
        }

        public static double[] CosinePeriodic(int width)
        {
            var phaseStep = Math.PI / width;

            var w = new double[width];
            for (var i = 0; i < w.Length; i++) w[i] = Math.Sin(i * phaseStep);
            return w;
        }

        public static double[] Gauss(int width, double sigma)
        {
            var a = (width - 1) / 2.0;

            var w = new double[width];
            for (var i = 0; i < w.Length; i++)
            {
                var exponent = (i - a) / (sigma * a);
                w[i] = Math.Exp(-0.5 * exponent * exponent);
            }

            return w;
        }

        public static double[] Blackman(int width)
        {
            const double alpha = 0.16;
            const double a = 0.5 - 0.5 * alpha;
            const double b = 0.5 * alpha;

            var last = width - 1;
            var c = 2.0 * Math.PI / last;
            var d = 2.0 * c;

            var w = new double[width];
            for (var i = 0; i < w.Length; i++)
                w[i] = a
                       - 0.5 * Math.Cos(i * c)
                       + b * Math.Cos(i * d);
            return w;
        }

        public static double[] BlackmanHarris(int width)
        {
            const double a = 0.35875;
            const double b = -0.48829;
            const double c = 0.14128;
            const double d = -0.01168;

            var last = width - 1;
            var e = 2.0 * Math.PI / last;
            var f = 2.0 * e;
            var g = 3.0 * e;

            var w = new double[width];
            for (var i = 0; i < w.Length; i++)
                w[i] = a
                       + b * Math.Cos(e * i)
                       + c * Math.Cos(f * i)
                       + d * Math.Cos(g * i);
            return w;
        }

        public static double[] BlackmanNuttall(int width)
        {
            const double a = 0.3635819;
            const double b = -0.4891775;
            const double c = 0.1365995;
            const double d = -0.0106411;

            var last = width - 1;
            var e = 2.0 * Math.PI / last;
            var f = 2.0 * e;
            var g = 3.0 * e;

            var w = new double[width];
            for (var i = 0; i < w.Length; i++)
                w[i] = a
                       + b * Math.Cos(e * i)
                       + c * Math.Cos(f * i)
                       + d * Math.Cos(g * i);
            return w;
        }

        public static double[] Bartlett(int width)
        {
            var last = width - 1;
            var a = 2.0 / last;
            var b = last / 2.0;

            var w = new double[width];
            for (var i = 0; i < w.Length; i++) w[i] = a * (b - Math.Abs(i - b));
            return w;
        }

        public static double[] BartlettHann(int width)
        {
            const double a = 0.62;
            const double b = -0.48;
            const double c = -0.38;

            var last = width - 1;
            var d = 1.0 / last;
            var e = 2.0 * Math.PI / last;

            var w = new double[width];
            for (var i = 0; i < w.Length; i++)
                w[i] = a
                       + b * Math.Abs(i * d - 0.5)
                       + c * Math.Cos(i * e);
            return w;
        }

        public static double[] Nuttall(int width)
        {
            const double a = 0.355768;
            const double b = -0.487396;
            const double c = 0.144232;
            const double d = -0.012604;

            var last = width - 1;
            var e = 2.0 * Math.PI / last;
            var f = 2.0 * e;
            var g = 3.0 * e;

            var w = new double[width];
            for (var i = 0; i < w.Length; i++)
                w[i] = a
                       + b * Math.Cos(e * i)
                       + c * Math.Cos(f * i)
                       + d * Math.Cos(g * i);
            return w;
        }

        public static double[] FlatTop(int width)
        {
            const double a = 1.0;
            const double b = -1.93;
            const double c = 1.29;
            const double d = -0.388;
            const double e = 0.032;

            var last = width - 1;
            var f = 2.0 * Math.PI / last;
            var g = 2.0 * f;
            var h = 3.0 * f;
            var k = 4.0 * f;

            var w = new double[width];
            for (var i = 0; i < w.Length; i++)
                w[i] = a
                       + b * Math.Cos(f * i)
                       + c * Math.Cos(g * i)
                       + d * Math.Cos(h * i)
                       + e * Math.Cos(k * i);
            return w;
        }

        public static double[] Dirichlet(int width)
        {
            var w = new double[width];
            for (var i = 0; i < w.Length; i++) w[i] = 1.0;
            return w;
        }

        public static double[] Triangular(int width)
        {
            var a = 2.0 / width;
            var b = width / 2.0;
            var c = (width - 1) / 2.0;

            var w = new double[width];
            for (var i = 0; i < w.Length; i++) w[i] = a * (b - Math.Abs(i - c));
            return w;
        }
    }

    #endregion

    #endregion
}