using System.Collections.Generic;

namespace WestCoastEducation_App.Interfaces;

public interface IStorage<T> where T : class
{
    List<T> Read(string path);
    void Write(string path, List<T> data);
}
