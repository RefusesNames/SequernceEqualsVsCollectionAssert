# Benchmark `List.SequenceEqual` vs. `CollectionAssert.AreEqual`

According to [an old StackOverflow entry](https://stackoverflow.com/a/11055686/5909613)
(see in its comments), `CollectionAssert.AreEqual` is very slow and should be replaced
by `List.SequenceEqual` if performance matters. This project exists to measure that.

## Results
| Method                         | ProblemSize | Mean           | Error         | StdDev        |
|------------------------------- |------------ |---------------:|--------------:|--------------:|
| CollectionAssert_AreEqual      | 10          |   1,974.093 ns |     5.9869 ns |     4.6742 ns |
| CollectionAssert_AreEquivalent | 10          |   2,469.608 ns |    21.1992 ns |    17.7023 ns |
| SequenceEqual                  | 10          |       3.321 ns |     0.0363 ns |     0.0322 ns |
| AssertSequenceEqual            | 10          |   1,705.580 ns |     9.2268 ns |     8.1793 ns |
| CollectionAssert_AreEqual      | 100         |   2,511.009 ns |    27.7636 ns |    24.6117 ns |
| CollectionAssert_AreEquivalent | 100         |   5,928.349 ns |    66.2310 ns |    61.9525 ns |
| SequenceEqual                  | 100         |       7.150 ns |     0.0564 ns |     0.0528 ns |
| AssertSequenceEqual            | 100         |   1,702.024 ns |    13.1136 ns |    12.2665 ns |
| CollectionAssert_AreEqual      | 1000        |   7,060.439 ns |    78.5242 ns |    69.6097 ns |
| CollectionAssert_AreEquivalent | 1000        |  45,565.166 ns |   905.0634 ns | 1,632.0162 ns |
| SequenceEqual                  | 1000        |      48.288 ns |     0.1757 ns |     0.1558 ns |
| AssertSequenceEqual            | 1000        |   1,781.720 ns |    18.9940 ns |    17.7670 ns |
| CollectionAssert_AreEqual      | 10000       |  52,976.775 ns |   842.6284 ns |   746.9681 ns |
| CollectionAssert_AreEquivalent | 10000       | 768,400.573 ns | 7,837.3499 ns | 7,331.0620 ns |
| SequenceEqual                  | 10000       |     531.035 ns |     4.1039 ns |     3.8388 ns |
| AssertSequenceEqual            | 10000       |   2,282.395 ns |    18.8348 ns |    17.6181 ns |

