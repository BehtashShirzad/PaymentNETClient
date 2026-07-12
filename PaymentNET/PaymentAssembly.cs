using System.Reflection;
using PaymentNET.Standard;

namespace PaymentNET;

public static class PaymentAssembly
{
    public static Assembly Assembly => typeof(PaymentAssembly).Assembly;
}