using BenchmarkDotNet.Running;
using CollectionAssertSlow;

var summary = BenchmarkRunner.Run<Benchmark>();
