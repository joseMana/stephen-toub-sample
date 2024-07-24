using System;
using System.Collections;
using System.Collections.Generic;

public class EmployeeRecord
{
    public string Name { get; set; }
    public string Position { get; set; }
    public int Salary { get; set; }
    public int DepartmentId { get; set; }
}
public class DepartmentRecord
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}
public class EmployeeDepartment
{
    public string EmployeeName { get; set; }
    public string Position { get; set; }
    public int Salary { get; set; }
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; }
}
public static class ListExtensions
{
    public static List<EmployeeDepartment> LeftJoin(this List<EmployeeRecord> employees, List<DepartmentRecord> departments, Func<EmployeeRecord, DepartmentRecord, bool> condition)
    {
        var result = new List<EmployeeDepartment>();

        foreach (var employee in employees)
        {
            bool matchFound = false;
            foreach (var department in departments)
            {
                if (condition(employee, department))
                {
                    result.Add(new EmployeeDepartment
                    {
                        EmployeeName = employee.Name,
                        Position = employee.Position,
                        Salary = employee.Salary,
                        DepartmentId = employee.DepartmentId,
                        DepartmentName = department.DepartmentName
                    });
                    matchFound = true;
                }
            }

            if (!matchFound)
            {
                result.Add(new EmployeeDepartment
                {
                    EmployeeName = employee.Name,
                    Position = employee.Position,
                    Salary = employee.Salary,
                    DepartmentId = employee.DepartmentId,
                    DepartmentName = "NULL" //null // or string.Empty, depending on your preference
                });
            }
        }

        return result;
    }

    public static List<EmployeeDepartment> LeftJoin(this List<DepartmentRecord> departments, List<EmployeeRecord> employees, Func<DepartmentRecord, EmployeeRecord, bool> condition)
    {
        var result = new List<EmployeeDepartment>();

        foreach (var department in departments)
        {
            bool matchFound = false;
            foreach (var employee in employees)
            {
                if (condition(department, employee))
                {
                    result.Add(new EmployeeDepartment
                    {
                        EmployeeName = employee.Name,
                        Position = employee.Position,
                        Salary = employee.Salary,
                        DepartmentId = employee.DepartmentId,
                        DepartmentName = department.DepartmentName
                    });
                    matchFound = true;
                }
            }

            if (!matchFound)
            {
                result.Add(new EmployeeDepartment
                {
                    EmployeeName = "NULL", //null // or string.Empty, depending on your preference
                    Position = "NULL", //null // or string.Empty, depending on your preference
                    Salary = 0,
                    DepartmentId = department.DepartmentId,
                    DepartmentName = department.DepartmentName
                });
            }
        }

        return result;
    }

    public static List<EmployeeDepartment> InnerJoin(this List<EmployeeRecord> employees, List<DepartmentRecord> departments, Func<EmployeeRecord, DepartmentRecord, bool> condition)
    {
        var result = new List<EmployeeDepartment>();

        foreach (var employee in employees)
        {
            foreach (var department in departments)
            {
                if (condition(employee, department))
                {
                    result.Add(new EmployeeDepartment
                    {
                        EmployeeName = employee.Name,
                        Position = employee.Position,
                        Salary = employee.Salary,
                        DepartmentId = employee.DepartmentId,
                        DepartmentName = department.DepartmentName
                    });
                }
            }
        }
        return result;
    }

    public static List<EmployeeDepartment> InnerJoin(this List<DepartmentRecord> departments, List<EmployeeRecord> employees, Func<DepartmentRecord, EmployeeRecord, bool> condition)
    {
        var result = new List<EmployeeDepartment>();

        foreach (var department in departments)
        {
            foreach (var employee in employees)
            {
                if (condition(department, employee))
                {
                    result.Add(new EmployeeDepartment
                    {
                        EmployeeName = employee.Name,
                        Position = employee.Position,
                        Salary = employee.Salary,
                        DepartmentId = employee.DepartmentId,
                        DepartmentName = department.DepartmentName
                    });
                }
            }
        }
        return result;
    }
    public static List<EmployeeDepartment> Union(
    this List<EmployeeDepartment> list1,
    List<EmployeeDepartment> list2)
    {
        var result = new List<EmployeeDepartment>();

        // Use a HashSet to track unique items based on a key, such as a combination of EmployeeName and DepartmentId
        var seen = new HashSet<(string, int)>();

        foreach (var item in list1)
        {
            var key = (item.EmployeeName, item.DepartmentId);
            if (seen.Add(key))
            {
                result.Add(item);
            }
        }

        foreach (var item in list2)
        {
            var key = (item.EmployeeName, item.DepartmentId);
            if (seen.Add(key))
            {
                result.Add(item);
            }
        }

        // Sorting the result list
        result.Sort((x, y) =>
        {
            int nameComparison = string.Compare(x.EmployeeName, y.EmployeeName);
            if (nameComparison != 0) return nameComparison;

            // Assuming DepartmentId is the secondary key for sorting
            return x.DepartmentId.CompareTo(y.DepartmentId);
        });

        return result;
    }
}
public class Program
{
    public static void Main()
    {
        var employees = new List<EmployeeRecord>
        {
            new EmployeeRecord { Name = "John", Position = "Manager", Salary = 3000, DepartmentId = 1 },
            new EmployeeRecord { Name = "Alice", Position = "Manager", Salary = 3000, DepartmentId = 2 },
            new EmployeeRecord { Name = "Bob", Position = "Developer", Salary = 2000, DepartmentId = 1 },
            new EmployeeRecord { Name = "Charlie", Position = "Developer", Salary = 2000, DepartmentId = 2 },
            new EmployeeRecord { Name = "David", Position = "Developer", Salary = 2000, DepartmentId = 3 },
            new EmployeeRecord { Name = "Eve", Position = "Developer", Salary = 2000, DepartmentId = 3 }
        };

        var departments = new List<DepartmentRecord>
        {
            new DepartmentRecord { DepartmentId = 1, DepartmentName = "Engineering" },
            new DepartmentRecord { DepartmentId = 2, DepartmentName = "Sales" }
        };

        //var joinedList = employees.LeftJoin(departments, (e, d) => e.DepartmentId == d.DepartmentId);
        //foreach (var item in joinedList)
        //{
        //    Console.WriteLine($"{item.EmployeeName} - {item.Position} - {item.Salary} - {item.DepartmentName}");
        //}

        var joinedList = departments.LeftJoin(employees, (e, d) => e.DepartmentId == d.DepartmentId);
        foreach (var item in joinedList)
        {
            Console.WriteLine($"{item.EmployeeName} - {item.Position} - {item.Salary} - {item.DepartmentName}");
        }

        var list1 = new List<EmployeeDepartment>
        {
            new EmployeeDepartment { EmployeeName = "John", Position = "Manager", Salary = 3000, DepartmentId = 1, DepartmentName = "Engineering" },
            new EmployeeDepartment { EmployeeName = "Alice", Position = "Manager", Salary = 3000, DepartmentId = 2, DepartmentName = "Sales" }
        };
        var list2 = new List<EmployeeDepartment>
        {
            new EmployeeDepartment { EmployeeName = "Alice", Position = "Manager", Salary = 3000, DepartmentId = 2, DepartmentName = "Sales" },
            new EmployeeDepartment { EmployeeName = "Alice", Position = "Manager", Salary = 3000, DepartmentId = 2, DepartmentName = "Sales" }
        };
        var unionResult = list1.Union(list2);


        Console.ReadLine();
    }
}
