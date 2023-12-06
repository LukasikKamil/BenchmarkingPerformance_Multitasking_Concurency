﻿await foreach (int number in GetNumberAsync())
{
    WriteLine($"Number: {number}");
}

async static IAsyncEnumerable<int> GetNumberAsync()
{
    Random r = Random.Shared;

    // simulate work
    await Task.Delay(r.Next(1500, 3000));
    yield return r.Next(0, 1001);

    await Task.Delay(r.Next(1500, 3000));
    yield return r.Next(0, 1001);
    await Task.Delay(r.Next(1500, 3000));
    yield return r.Next(0, 1001);
}