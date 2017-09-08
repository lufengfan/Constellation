#define DelayQuerySupport
#define OPTIMIZE

using System;
using System.Collections.Generic;
using System.Linq;

namespace SamLu.Math
{
    /// <summary>
    /// 提供用于生成一组元素的组合的方法。
    /// </summary>
    public static class Combination
    {
#if DelayQuerySupport
        /// <summary>
        /// 生成一组元素的组合。
        /// </summary>
        /// <param name="elements">进行组合的元素列表。</param>
        /// <typeparam name="T">元素的类型。</typeparam>
        /// <returns>
        /// <para>包含所有可能的组合情况。</para>
        /// <para>如果 <paramref name="elements" /> 中的元素个数为零，则返回一个空列表。</para>
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="elements" /> 为 null 。
        /// </exception>
        /// <remarks>
        /// <para>对给定的一组元素进行组合，并返回所有可能的组合情况。</para>
        /// <para>此方法返回的集合支持延迟查询，在循环遍历集合时将单独逐步计算各项。</para>
        /// </remarks>
        public static IEnumerable<IList<T>> GetCombinations<T>(IList<T> elements)
        {
            if (elements == null)
                throw new ArgumentNullException(nameof(elements));

            if (elements.Count == 0)
                return Enumerable.Empty<IList<T>>();

            return GetCombinationsWithRank(elements, elements.Count);
        }
#else
		/// <summary>
		/// 生成一组元素的组合。
		/// </summary>
		/// <param name="elements">进行组合的元素列表。</param>
		/// <typeparam name="T">元素的类型。</typeparam>
		/// <returns>
		/// <para>包含所有可能的组合情况。</para>
		/// <para>如果 <paramref name="elements" /> 中的元素个数为零，则返回一个空列表。</para>
		/// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="elements" /> 为 null 。
        /// </exception>
		/// <remarks>
		/// 对给定的一组元素进行组合，并返回所有可能的组合情况。
		/// </remarks>
		public static IEnumerable<IList<T>> GetCombinations<T>(IList<T> elements)
		{
			if (elements == null)
				throw new ArgumentNullException(nameof(elements));

			if (elements.Count == 0)
				return Enumerable.Empty<IList<T>>();

			return GetCombinationsWithRank(elements, elements.Count);
		}
#endif

#if DelayQuerySupport
        /// <summary>
        /// 以特定的秩生成一组元素的组合。
        /// </summary>
        /// <param name="elements">进行组合的元素列表。</param>
        /// <param name="rank">秩，选取元素的个数。</param>
        /// <typeparam name="T">元素的类型。</typeparam>
        /// <returns>
        /// <para>包含所有可能的组合情况。</para>
        /// <para>如果 <paramref name="elements" /> 中的元素个数为零，则返回一个空的列表。</para>
        /// </returns>
        /// <seealso cref="IEnumerable{T}" />
        /// <seealso cref="IList{T}" />
        /// <exception cref="ArgumentNullException">
        /// <paramref name="elements" /> 为 <see langword="null"/> 。
        /// </exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="rank" /> 的值为负数，或者大于 <paramref name="elements" /> 中元素的个数。
        /// </exception>
        /// <remarks>
        /// <para>对给定的一组元素中任意选取特定个进行组合，并返回所有可能的组合情况。</para>
        /// <para>此方法返回的集合支持延迟查询，在循环遍历集合时将单独逐步计算各项。</para>
        /// </remarks>
        public static IEnumerable<IList<T>> GetCombinationsWithRank<T>(IList<T> elements, int rank)
        {
            if (elements == null)
                throw new ArgumentNullException(nameof(elements));

            if ((rank < 0) || (rank > elements.Count))
                throw new ArgumentOutOfRangeException(nameof(elements), rank, string.Format("{0}应不小于零且小于{1}中元素的个数。", nameof(rank), nameof(elements)));

            if ((elements.Count == 0) || (rank == 0))
                return Enumerable.Empty<IList<T>>();

            IList<T> item = new List<T>(
#if OPTIMIZE
                elements.Count
#endif
            );
            int[] indexes = new int[rank];

            return GetCombinationsWithRankInternal(elements, item, indexes, 1, rank);
        }
#else
		/// <summary>
		/// 以特定的秩生成一组元素的组合。
		/// </summary>
		/// <param name="elements">进行组合的元素列表。</param>
		/// <param name="rank">秩，选取元素的个数。</param>
		/// <typeparam name="T">元素的类型。</typeparam>
		/// <returns>
		/// <para>包含所有可能的组合情况。</para>
		/// <para>如果 <paramref name="elements" /> 中的元素个数为零，则返回一个空列表。</para>
		/// </returns>
		/// <seealso cref="IEnumerable{T}" />
		/// <seealso cref="IList{T}" />
		/// <exception cref="ArgumentNullException">
		/// <paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		/// <exception cref="ArgumentOutOfRangeException">
		/// <paramref name="rank" /> 的值为负数，或者大于 <paramref name="elements" /> 中元素的个数。
		/// </exception>
		/// <remarks>
		/// 对给定的一组元素中任意选取特定个进行组合，并返回所有可能的组合情况。
		/// </remarks>
		public static IEnumerable<IList<T>> GetCombinationsWithRank<T>(IList<T> elements, int rank)
		{
			if (elements == null)
				throw new ArgumentNullException(nameof(elements));

			if ((rank < 0) || (rank > elements.Count))
				throw new ArgumentOutOfRangeException(nameof(elements), rank, string.Format("{0} 应不小于零且小于 {1} 中元素的个数。", nameof(rank), nameof(elements)));

			if ((elements.Count == 0) || (rank == 0))
				return Enumerable.Empty<IList<T>>();

			IList<T> tempList = new List<T>(elements);
			IList<T> item = new List<T>(
#if OPTIMIZE
				elements.Count
#endif
			);
			IList<IList<T>> result = new List<IList<T>>(
#if OPTIMIZE
				Math.Combination(elements.Count, elements.Count)
#endif
			);
			int[] indexes = new int[rank];

            GetCombinationsWithRankInternal(tempList, item, result, indexes, 1, rank);

			return result;
		}
#endif

#if DelayQuerySupport
        /// <summary>
        /// 生成一组元素在所有秩上组合的集合。
        /// </summary>
        /// <param name="elements">进行组合的元素列表。</param>
        /// <typeparam name="T">元素的类型。</typeparam>
        /// <returns>
        /// <para>包含所有可能的组合情况。</para>
        /// <para>如果 <paramref name="elements" /> 中的元素个数为零，则返回一个空列表。</para>
        /// </returns>
        /// <seealso cref="IEnumerable{T}" />
        /// <seealso cref="IList{T}" />
        /// <exception cref="ArgumentNullException">
        /// <paramref name="elements" /> 为 <see langword="null"/> 。
        /// </exception>
        /// <remarks>
        /// <para>对给定的一组元素从最低秩到最高秩进行组合，并返回所有可能的组合情况。</para>
        /// <para>此方法返回的集合支持延迟查询，在循环遍历集合时将单独逐步计算各项。</para>
        /// </remarks>
        public static IEnumerable<IList<T>> GetOptionalCombinations<T>(IList<T> elements)
        {
            if (elements == null)
                throw new ArgumentNullException(nameof(elements));

            if (elements.Count == 0)
                yield break;

#if OPTIMIZE
            int count = 0;
            for (int rank = 1; rank <= elements.Count; rank++)
                count += Math.Combination(elements.Count, rank);
#endif

            for (int rank = 1; rank <= elements.Count; rank++)
                foreach (IList<T> _item in GetCombinationsWithRank(elements, rank))
                    yield return _item;
        }
#else
		/// <summary>
		/// 生成一组元素在所有秩上组合的集合。
		/// </summary>
		/// <param name="elements">进行组合的元素列表。</param>
		/// <typeparam name="T">元素的类型。</typeparam>
		/// <returns>
		/// <para>包含所有可能的组合情况。</para>
		/// <para>如果 <paramref name="elements" /> 中的元素个数为零，则返回一个空列表。</para>
		/// </returns>
		/// <seealso cref="IEnumerable{T}" />
		/// <seealso cref="IList{T}" />
		/// <exception cref="ArgumentNullException">
		/// <paramref name="elements" /> 为 <see langword="null"/> 。
		/// </exception>
		/// <remarks>
		/// 对给定的一组元素从最低秩到最高秩进行组合，并返回所有可能的组合情况。
		/// </remarks>
		public static IEnumerable<IList<T>> GetOptionalCombinations<T>(IList<T> elements)
		{
			if (elements == null)
				throw new ArgumentNullException(nameof(elements));

			if (elements.Count == 0)
				return Enumerable.Empty<IList<T>>();

#if OPTIMIZE
			int count = 0;
			for (int rank = 1; rank <= elements.Count; rank++)
				count += Math.Combination(elements.Count, rank);
#endif

			List<IList<T>> result = new List<IList<T>>(
#if OPTIMIZE
				count
#endif
			);

			for (int rank = 1; rank <= elements.Count; rank++)
				result.AddRange(GetCombinationsWithRank(elements, rank));

			return result;
		}
#endif

#if DelayQuerySupport
        /// <summary>
        /// 生成一组元素在所有秩上组合的集合的迭代器的内部方法。
        /// </summary>
        /// <typeparam name="T">元素的类型。</typeparam>
        /// <param name="elements">进行组合的元素列表。</param>
        /// <param name="item">其中一种组合情况。</param>
        /// <param name="indexes">各层迭代时选择的元素索引</param>
        /// <param name="currentRank">当前秩。</param>
        /// <param name="rank">秩。</param>
        /// <returns>
        /// <para>包含所有可能的组合情况的迭代器。</para>
        /// <para>如果 <paramref name="elements" /> 中的元素个数为零，则返回一个空列表。</para>
        /// </returns>
        /// <remarks>
        /// <para>支持对给定的一组元素从指定的低秩 <paramref name="currentRank" /> 到最高秩 <paramref name="rank" /> 进行组合操作。</para>
        /// <para>此方法返回的集合支持延迟查询，在循环遍历集合时将单独逐步计算各项。</para>
        /// <para><strong>此方法为内部方法，仅供内部维护人员参阅。</strong></para>
        /// </remarks>
        private static IEnumerable<IList<T>> GetCombinationsWithRankInternal<T>(IList<T> elements, IList<T> item, int[] indexes, int currentRank, int rank)
        {
            if (currentRank == rank + 1)
            {
                yield return new List<T>(item);

                yield break;
            }

            for (
                indexes[currentRank - 1] = ((currentRank == 1) ? 0 : (indexes[currentRank - 2] + 1));
                indexes[currentRank - 1] < (elements.Count + currentRank - rank);
                indexes[currentRank - 1]++
            )
            {
                item.Add(elements[indexes[currentRank - 1]]);
                foreach (IList<T> _item in GetCombinationsWithRankInternal(elements, item, indexes, currentRank + 1, rank)) yield return _item;
                item.RemoveAt(item.Count - 1);
            }
        }
#else
		/// <summary>
		/// 生成一组元素在所有秩上组合的集合的内部方法。
		/// </summary>
		/// <param name="elements">进行组合的元素列表。</param>
		/// <param name="item">其中一种组合情况。</param>
		/// <param name="result">组合情况的结果。</param>
		/// <param name="indexes">各层迭代时选择的元素索引</param>
		/// <param name="currentRank">当前秩。</param>
		/// <param name="rank">秩。</param>
		/// <typeparam name="T">元素的类型。</typeparam>
		/// <remarks>
		/// <para>支持对给定的一组元素从指定的低秩 <paramref name="currentRank" /> 到最高秩 <paramref name="rank" /> 进行组合操作。</para>
		/// <para><strong>此方法为内部方法，仅供内部维护人员参阅。</strong></para>
		/// </remarks>
		private static void GetCombinationsWithRankInternal<T>(IList<T> elements, IList<T> item, IList<IList<T>> result, int[] indexes, int currentRank, int rank)
		{
			if (currentRank == rank + 1)
			{
				result.Add(new List<T>(item));
				
				return;
			}
			
			for (
				indexes[currentRank - 1] = ((currentRank == 1) ? 0 : (indexes[currentRank - 2] + 1)); 
				indexes[currentRank - 1] < (elements.Count + currentRank - rank); 
				indexes[currentRank - 1]++
			)
			{
				item.Add(elements[indexes[currentRank - 1]]);
                GetCombinationsWithRankInternal(elements, item, result, indexes, currentRank + 1, rank);
				item.RemoveAt(item.Count - 1);
			}
		}
#endif
    }
}