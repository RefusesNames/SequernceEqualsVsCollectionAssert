# Benchmark `List.SequenceEqual` vs. `CollectionAssert.AreEqual`

According to [an old StackOverflow entry](https://stackoverflow.com/a/11055686/5909613)
(see in its comments), `CollectionAssert.AreEqual` is very slow and should be replaced
by `List.SequenceEqual` if performance matters. This project exists to measure that.

## Results
| Method                         | ProblemSize | Mean           | Error         | StdDev        |
|------------------------------- |------------ |---------------:|--------------:|--------------:|
| CollectionAssert_AreEqual      | 10          |   1,990.924 ns |    11.0171 ns |     9.1997 ns |
| CollectionAssert_AreEquivalent | 10          |   2,547.870 ns |    17.5956 ns |    14.6931 ns |
| SequenceEqual                  | 10          |       3.327 ns |     0.0331 ns |     0.0310 ns |
| CollectionAssert_AreEqual      | 100         |   2,494.877 ns |    33.0485 ns |    30.9136 ns |
| CollectionAssert_AreEquivalent | 100         |   6,458.927 ns |    63.9854 ns |    59.8520 ns |
| SequenceEqual                  | 100         |       7.303 ns |     0.0493 ns |     0.0461 ns |
| CollectionAssert_AreEqual      | 1000        |   7,316.004 ns |    94.3565 ns |    88.2611 ns |
| CollectionAssert_AreEquivalent | 1000        |  38,867.322 ns |   750.2078 ns |   701.7448 ns |
| SequenceEqual                  | 1000        |      42.065 ns |     0.3527 ns |     0.3127 ns |
| CollectionAssert_AreEqual      | 10000       |  52,085.830 ns |   548.9059 ns |   458.3613 ns |
| CollectionAssert_AreEquivalent | 10000       | 666,003.197 ns | 7,530.5573 ns | 7,044.0879 ns |
| SequenceEqual                  | 10000       |     529.526 ns |     2.3010 ns |     1.9215 ns |

## Note
Take these test results with a grain of salt as `BenchmarkDotNet` is ill equipped to
benchmark calls that throw exceptions, like assertions do. It is not clear how much of
the difference is just the exception handling.

