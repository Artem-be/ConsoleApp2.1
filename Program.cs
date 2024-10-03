using System;

// Компоненты компьютера
public class CPU
{
    public string Name { get; }
    public int Cores { get; }
    public double Frequency { get; }

    public CPU(string name, int cores, double frequency)
    {
        Name = name;
        Cores = cores;
        Frequency = frequency;
    }

    public override string ToString()
    {
        return $"CPU: {Name}, Cores: {Cores}, Frequency: {Frequency} GHz";
    }
}

public class Motherboard
{
    public string Name { get; }
    public string FormFactor { get; }

    public Motherboard(string name, string formFactor)
    {
        Name = name;
        FormFactor = formFactor;
    }

    public override string ToString()
    {
        return $"Motherboard: {Name}, Form Factor: {FormFactor}";
    }
}

public class RAM
{
    public string Name { get; }
    public int Size { get; }
    public int Frequency { get; }

    public RAM(string name, int size, int frequency)
    {
        Name = name;
        Size = size;
        Frequency = frequency;
    }

    public override string ToString()
    {
        return $"RAM: {Name}, Size: {Size} GB, Frequency: {Frequency} MHz";
    }
}

public class Storage
{
    public string Name { get; }
    public double Size { get; }

    public Storage(string name, double size)
    {
        Name = name;
        Size = size;
    }

    public override string ToString()
    {
        return $"Storage: {Name}, Size: {Size} TB";
    }
}

public class GPU
{
    public string Name { get; }
    public int Memory { get; }

    public GPU(string name, int memory)
    {
        Name = name;
        Memory = memory;
    }

    public override string ToString()
    {
        return $"GPU: {Name}, Memory: {Memory} GB";
    }
}

// Класс компьютера
public class Computer
{
    public CPU Cpu { get; }
    public Motherboard Motherboard { get; }
    public RAM Ram { get; }
    public Storage Storage { get; }
    public GPU Gpu { get; }

    public Computer(CPU cpu, Motherboard motherboard, RAM ram, Storage storage, GPU gpu)
    {
        Cpu = cpu;
        Motherboard = motherboard;
        Ram = ram;
        Storage = storage;
        Gpu = gpu;
    }

    public override string ToString()
    {
        return $"{Cpu}\n{Motherboard}\n{Ram}\n{Storage}\n{Gpu}";
    }
}

// Строитель компьютера
public class ComputerBuilder
{
    private CPU _cpu;
    private Motherboard _motherboard;
    private RAM _ram;
    private Storage _storage;
    private GPU _gpu;

    public ComputerBuilder SetCPU(string name, int cores, double frequency)
    {
        _cpu = new CPU(name, cores, frequency);
        return this;
    }

    public ComputerBuilder SetMotherboard(string name, string formFactor)
    {
        _motherboard = new Motherboard(name, formFactor);
        return this;
    }

    public ComputerBuilder SetRAM(string name, int size, int frequency)
    {
        _ram = new RAM(name, size, frequency);
        return this;
    }

    public ComputerBuilder SetStorage(string name, double size)
    {
        _storage = new Storage(name, size);
        return this;
    }

    public ComputerBuilder SetGPU(string name, int memory)
    {
        _gpu = new GPU(name, memory);
        return this;
    }

    public Computer Build()
    {
        if (_cpu == null || _motherboard == null || _ram == null || _storage == null || _gpu == null)
        {
            throw new InvalidOperationException("All components must be set before building the computer.");
        }
        return new Computer(_cpu, _motherboard, _ram, _storage, _gpu);
    }
}

// Пример использования
class Program
{
    static void Main(string[] args)
    {
        var builder = new ComputerBuilder();
        Computer computer = builder
            .SetCPU("Intel Core i7", 8, 3.6)
            .SetMotherboard("ASUS ROG Strix", "ATX")
            .SetRAM("Corsair Vengeance", 16, 3200)
            .SetStorage("Samsung 970 EVO", 1)
            .SetGPU("NVIDIA GeForce RTX 3070", 8)
            .Build();

        Console.WriteLine(computer);
    }
}