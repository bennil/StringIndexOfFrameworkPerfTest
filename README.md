This repo contains a benchmark to reproduce the string.IndexOf(string) .NET 8.0 (other version also affected) performance issue running in culture context other than English/Invariant culture.

```

BenchmarkDotNet v0.13.11, Windows 11 (10.0.22621.2861/22H2/2022Update/SunValley2)
Intel Core i7-8650U CPU 1.90GHz (Kaby Lake R), 1 CPU, 8 logical and 4 physical cores
  [Host]               : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256
  .NET 5.0             : .NET 5.0.7 (5.0.721.25508), X64 RyuJIT AVX2
  .NET 8.0             : .NET 8.0.0 (8.0.23.53103), X64 RyuJIT AVX2
  .NET Framework 4.7.2 : .NET Framework 4.8.1 (4.8.9181.0), X64 RyuJIT VectorSize=256


```
| Method                                    | Job                  | Runtime              | Mean      | Error     | StdDev    | Ratio | RatioSD |
|------------------------------------------ |--------------------- |--------------------- |----------:|----------:|----------:|------:|--------:|
| IndexOfOfNotContainingStringInLargeString | .NET 5.0             | .NET 5.0             | 20.210 ms | 0.3075 ms | 0.2877 ms | 12.79 |    0.16 |
| IndexOfOfNotContainingStringInLargeString | .NET 8.0             | .NET 8.0             | 17.440 ms | 0.2713 ms | 0.2538 ms | 11.04 |    0.15 |
| IndexOfOfNotContainingStringInLargeString | .NET Framework 4.7.2 | .NET Framework 4.7.2 |  1.578 ms | 0.0098 ms | 0.0087 ms |  1.00 |    0.00 |


[See issue 96221](https://github.com/dotnet/runtime/issues/96221)