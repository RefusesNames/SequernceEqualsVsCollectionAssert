using BenchmarkDotNet.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CollectionAssertSlow;

public class Benchmark
{
	private readonly Random _random = new();

	/// <summary>
	/// A list of <see cref="ProblemSize"/> random integers
	/// </summary>
	private List<int>? _list1;

	/// <summary>
	/// A copy of <see cref="_list1"/> except for the last element, which is different
	/// </summary>
	private List<int>? _list2;

	[Params(10, 100, 1000, 10000)]
	public int ProblemSize;

	[GlobalSetup]
	public void Setup()
	{
		_list1 = new List<int>(capacity: ProblemSize);
		_list2 = new List<int>(capacity: ProblemSize);
		_list1.AddRange(
				Enumerable.Range(1, ProblemSize)
				.Select(i => _random.Next(ProblemSize)));
		_list2.AddRange(_list1);
		_list2[^1] += 1;
	}

	[Benchmark]
	public void CollectionAssert_AreEqual()
	{
		try
		{
			CollectionAssert.AreEqual(_list1, _list2);
		}
		catch(AssertFailedException)
		{
		}
	}

	[Benchmark]
	public void CollectionAssert_AreEquivalent()
	{
		try
		{
			CollectionAssert.AreEquivalent(_list1, _list2);
		}
		catch(AssertFailedException)
		{
		}
	}

	[Benchmark]
	public bool SequenceEqual()
		=> _list1!.SequenceEqual(_list2!);
}
