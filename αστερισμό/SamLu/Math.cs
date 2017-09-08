using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SamLu.Math {
	/// <summary>
	/// 	为阶乘函数、组合数函数、排列数函数和其他函数提供常数和静态方法。
	/// </summary>
	public static class Math {
		/// <summary>
		/// 	交换两个 <see cref="bool" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="bool" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref bool lp, ref bool rp) {
			bool temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 <see cref="char" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="char" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref char lp, ref char rp) {
			char temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 <see cref="sbyte" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="sbyte" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref sbyte lp, ref sbyte rp) {
			sbyte temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 <see cref="byte" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="byte" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref byte lp, ref byte rp) {
			byte temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 <see cref="short" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="short" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref short lp, ref short rp) {
			short temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 <see cref="ushort" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="ushort" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref ushort lp, ref ushort rp) {
			ushort temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 <see cref="int" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="int" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref int lp, ref int rp) {
			int temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 <see cref="uint" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="uint" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref uint lp, ref uint rp) {
			uint temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 <see cref="long" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="long" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref long lp, ref long rp) {
			long temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 <see cref="ulong" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="ulong" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref ulong lp, ref ulong rp) {
			ulong temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 <see cref="float" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="float" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref float lp, ref float rp) {
			float temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 <see cref="double" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="double" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref double lp, ref double rp) {
			double temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 <see cref="decimal" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="decimal" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref decimal lp, ref decimal rp) {
			decimal temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 <see cref="string" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="string" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref string lp, ref string rp) {
			string temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 <see cref="object" /> 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 <see cref="object" /> 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的左侧变量</param>
		/// <param name="rp">需要交换的右侧变量</param>
		public static void Change(ref object lp, ref object rp) {
			object temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	交换两个 T 变量的值。
		/// </summary>
		/// <remarks>
		/// 	此方法用于交换两个类型为 T 的变量的值。
		/// </remarks>
		/// <param name="lp">需要交换的变量。</param>
		/// <param name="rp">需要交换的变量。</param>
		/// <typeparam name="T">变量的类型。</typeparam>
		/// <overloads>交换两个变量的值。</overloads>
		public static void Change<T>(ref T lp, ref T rp) {
			T temp = lp;
			lp = rp;
			rp = temp;
		}
		
		/// <summary>
		/// 	获得特定阶的阶乘结果。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得特定阶的阶乘运算结果。
		/// </remarks>
		/// <param name="rank">阶，阶乘运算的阶数。</param>
		/// <returns>
		/// 	阶乘运算结果
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		/// 	<paramref name="rank" /> 为负数。
		/// </exception>
		public static int Factorial(int rank) {
			if (rank < 0)
				throw new ArgumentOutOfRangeException("rank", rank, "rank不应为负数。");
			
			if (rank == 0) return 1;
			
			int result = 1;
			for (int currentRank = 1; currentRank <= rank; currentRank++)
				result *= currentRank;
			
			return result;
		}
		
		/// <summary>
		/// 	获得组合数。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得组合运算的结果。
		/// </remarks>
		/// <param name="bp">组合数的上标。</param>
		/// <param name="tp">组合数的下标。</param>
		/// <returns>
		/// 	组合数
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		/// 	<para><paramref name="bp" /> 或 <paramref name="tp" /> 为负数。</para>
		/// 	<para>- 或 -</para>
		/// 	<para>组合数下标 <paramref name="bp" /> 小于上标 <paramref name="tp" /> 。</para>
		/// </exception>
		public static int Combination(int bp, int tp) {
			if ((bp < 0) || (tp < 0))
				throw new ArgumentOutOfRangeException(
					"bp, tp", 
					string.Format("bp = {0}, tp = {1}", bp, tp), 
					"bp和tp不应为负数。"
				);
			
			if (bp < tp)
				throw new ArgumentOutOfRangeException(
					"bp, tp", 
					string.Format("bp = {0}, tp = {1}", bp, tp), 
					"bp应大于tp。"
				);
			
			return (int)(Permutation(bp, tp) / 
						 Permutation(tp, tp));
		}
		
		/// <summary>
		/// 	获得排列数。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得排列运算的结果。
		/// </remarks>
		/// <param name="bp">排列数的上标。</param>
		/// <param name="tp">排列数的下标。</param>
		/// <returns>
		/// 	排列数
		/// </returns>
		/// <exception cref="ArgumentOutOfRangeException">
		/// 	<para><paramref name="bp" /> 或 <paramref name="tp" /> 为负数。</para>
		/// 	<para>- 或 -</para>
		/// 	<para>排列数下标 <paramref name="bp" /> 小于上标 <paramref name="tp" /> 。</para>
		/// </exception>
		public static int Permutation(int bp, int tp) {
			if ((bp < 0) || (tp < 0))
				throw new ArgumentOutOfRangeException(
					"bp, tp", 
					string.Format("bp = {0}, tp = {1}", bp, tp), 
					"bp和tp不应为负数。"
				);
			
			if (bp < tp)
				throw new ArgumentOutOfRangeException(
					"bp, tp", 
					string.Format("bp = {0}, tp = {1}", bp, tp), 
					"bp应大于tp。"
				);
			
			return (int)(Factorial(bp) / 
						 Factorial(bp - tp));
		}
		
		/// <summary>
		/// 	获得一列 <see cref="bool" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="bool" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static bool MaxInRange(params bool[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="char" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="char" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static char MaxInRange(params char[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="sbyte" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="sbyte" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static sbyte MaxInRange(params sbyte[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="byte" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="byte" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static byte MaxInRange(params byte[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="short" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="short" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static short MaxInRange(params short[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="ushort" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="ushort" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static ushort MaxInRange(params ushort[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="int" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="int" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static int MaxInRange(params int[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="uint" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="uint" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static uint MaxInRange(params uint[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="long" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="long" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static long MaxInRange(params long[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="ulong" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="ulong" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static ulong MaxInRange(params ulong[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="float" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="float" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static float MaxInRange(params float[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="double" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="double" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static double MaxInRange(params double[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="decimal" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="decimal" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static decimal MaxInRange(params decimal[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="string" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="string" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static string MaxInRange(params string[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="object" /> 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="object" /> 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static object MaxInRange(params object[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 T 数据中的最大项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 T 的数据中最大的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <typeparam name="T">
		/// 	<para>元素的类型</para>
		/// 	<para>类型 <typeparamref name="T" /> 须实现接口 <see cref="IComparable{T}" /> 。</para>
		/// </typeparam>
		/// <seealso cref="IComparable{T}" />
		/// <returns>
		/// 	最大项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		/// <overloads>获得一列数据中的最大项。</overloads>
		public static T MaxInRange<T>(params T[] elements) where T : IComparable<T> {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Max();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="bool" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="bool" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static bool MinInRange(params bool[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="char" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="char" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static char MinInRange(params char[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="sbyte" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="sbyte" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static sbyte MinInRange(params sbyte[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="byte" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="byte" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static byte MinInRange(params byte[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="short" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="short" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static short MinInRange(params short[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="ushort" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="ushort" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static ushort MinInRange(params ushort[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="int" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="int" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static int MinInRange(params int[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="uint" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="uint" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static uint MinInRange(params uint[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="long" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="long" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static long MinInRange(params long[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="ulong" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="ulong" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static ulong MinInRange(params ulong[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="float" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="float" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static float MinInRange(params float[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="double" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="double" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static double MinInRange(params double[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="decimal" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="decimal" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static decimal MinInRange(params decimal[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="string" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="string" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static string MinInRange(params string[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 <see cref="object" /> 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 <see cref="object" /> 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据</param>
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		public static object MinInRange(params object[] elements) {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
		
		/// <summary>
		/// 	获得一列 T 数据中的最小项。
		/// </summary>
		/// <remarks>
		/// 	此方法用于获得一列类型为 T 的数据中最小的一项。
		/// </remarks>
		/// <param name="elements">一列数据。</param>
		/// <typeparam name="T">
		/// 	<para>元素的类型</para>
		/// 	<para>类型 <typeparamref name="T" /> 须实现接口 <see cref="IComparable{T}" /> 。</para>
		/// </typeparam>
		/// <seealso cref="IComparable{T}" />
		/// <returns>
		/// 	最小项
		/// </returns>
		/// <exception cref="ArgumentNullException">
		/// 	<paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		/// <overloads>获得一列数据中的最小项。</overloads>
		public static T MinInRange<T>(params T[] elements) where T : IComparable<T> {
			if (elements == null)
				throw new ArgumentNullException("elements");
			
			return elements.Min();
		}
	}
}