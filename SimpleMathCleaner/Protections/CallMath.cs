using dnlib.DotNet;
using dnlib.DotNet.Emit;
using System.Collections.Generic;
using static Logger;
using static Context;
using System.Linq;
using System.Reflection;

namespace SimpleMathCleaner.Protections
{
    class CallMath : Protection
    {
        public override void Run()
        {
            CallMathStep1();
        }

        public static void CallMathStep1()
        {
            foreach (TypeDef type in module.Types.Where(x => x.HasMethods).ToArray())
            {
                foreach (MethodDef method in type.Methods.Where(x => x.HasBody && x.Body.HasInstructions).ToArray())
                {
                    for (int i = 0; i < method.Body.Instructions.Count; i++)
                    {
                        if (method.Body.Instructions[i].OpCode == OpCodes.Call && method.Body.Instructions[i].Operand.ToString().Contains("System.Math::") && method.Body.Instructions[i].Operand.ToString().Contains("(System.Double)") && method.Body.Instructions[i - 1].OpCode == OpCodes.Ldc_R8)
                        {
                            MemberRef memberRef = (MemberRef)method.Body.Instructions[i].Operand;
                            MethodBase invoke = typeof(System.Math).GetMethod(memberRef.Name, new System.Type[] { typeof(double) });
                            double arg1 = (double)method.Body.Instructions[i - 1].Operand;
                            double result = (double)invoke.Invoke(null, new object[] { arg1 });
                            method.Body.Instructions[i].OpCode = OpCodes.Ldc_R8;
                            method.Body.Instructions[i].Operand = result;
                            method.Body.Instructions[i - 1].OpCode = OpCodes.Nop;
                            Write($"{invoke} : {result}", TypeMessage.Done);
                        }
                        if (method.Body.Instructions[i].OpCode == OpCodes.Call && method.Body.Instructions[i].Operand.ToString().Contains("System.Math::") && method.Body.Instructions[i].Operand.ToString().Contains("(System.Single)") && method.Body.Instructions[i - 1].OpCode == OpCodes.Ldc_R4)
                        {
                            MemberRef memberRef = (MemberRef)method.Body.Instructions[i].Operand;
                            MethodBase invoke = typeof(System.Math).GetMethod(memberRef.Name, new System.Type[] { typeof(float) });
                            float arg1 = (float)method.Body.Instructions[i - 1].Operand;
                            float result = (float)invoke.Invoke(null, new object[] { arg1 });
                            method.Body.Instructions[i].OpCode = OpCodes.Ldc_R4;
                            method.Body.Instructions[i].Operand = result;
                            method.Body.Instructions[i - 1].OpCode = OpCodes.Nop;
                            Write($"{invoke} : {result}", TypeMessage.Done);
                        }
                        if (method.Body.Instructions[i].OpCode == OpCodes.Call && method.Body.Instructions[i].Operand.ToString().Contains("System.Math::") && method.Body.Instructions[i].Operand.ToString().Contains("(System.Int32)") && method.Body.Instructions[i - 1].OpCode == OpCodes.Ldc_I4)
                        {
                            MemberRef memberRef = (MemberRef)method.Body.Instructions[i].Operand;
                            MethodBase invoke = typeof(System.Math).GetMethod(memberRef.Name, new System.Type[] { typeof(int) });
                            int arg1 = (int)method.Body.Instructions[i - 1].Operand;
                            int result = (int)invoke.Invoke(null, new object[] { arg1 });
                            method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
                            method.Body.Instructions[i].Operand = result;
                            method.Body.Instructions[i - 1].OpCode = OpCodes.Nop;
                            Write($"{invoke} : {result}", TypeMessage.Done);
                        }
                        if (method.Body.Instructions[i].OpCode == OpCodes.Call && method.Body.Instructions[i].Operand.ToString().Contains("System.Math::") && method.Body.Instructions[i].Operand.ToString().Contains("(System.Double,System.Double)") && method.Body.Instructions[i - 1].OpCode == OpCodes.Ldc_R8 && method.Body.Instructions[i - 2].OpCode == OpCodes.Ldc_R8)
                        {
                            MemberRef memberRef = (MemberRef)method.Body.Instructions[i].Operand;
                            MethodBase invoke = typeof(System.Math).GetMethod(memberRef.Name, new System.Type[] { typeof(double), typeof(double) });
                            double arg1 = (double)method.Body.Instructions[i - 1].Operand;
                            double arg2 = (double)method.Body.Instructions[i - 2].Operand;
                            double result = (double)invoke.Invoke(null, new object[] { arg1, arg2 });
                            method.Body.Instructions[i].OpCode = OpCodes.Ldc_R8;
                            method.Body.Instructions[i].Operand = result;
                            method.Body.Instructions[i - 1].OpCode = OpCodes.Nop;
                            method.Body.Instructions[i - 2].OpCode = OpCodes.Nop;
                            Write($"{invoke} : {result}", TypeMessage.Done);
                        }
                        if (method.Body.Instructions[i].OpCode == OpCodes.Call && method.Body.Instructions[i].Operand.ToString().Contains("System.Math::") && method.Body.Instructions[i].Operand.ToString().Contains("(System.Single,System.Single)") && method.Body.Instructions[i - 1].OpCode == OpCodes.Ldc_R4 && method.Body.Instructions[i - 2].OpCode == OpCodes.Ldc_R4)
                        {
                            MemberRef memberRef = (MemberRef)method.Body.Instructions[i].Operand;
                            MethodBase invoke = typeof(System.Math).GetMethod(memberRef.Name, new System.Type[] { typeof(float), typeof(float) });
                            float arg1 = (float)method.Body.Instructions[i - 1].Operand;
                            float arg2 = (float)method.Body.Instructions[i - 2].Operand;
                            float result = (float)invoke.Invoke(null, new object[] { arg1, arg2 });
                            method.Body.Instructions[i].OpCode = OpCodes.Ldc_R4;
                            method.Body.Instructions[i].Operand = result;
                            method.Body.Instructions[i - 1].OpCode = OpCodes.Nop;
                            method.Body.Instructions[i - 2].OpCode = OpCodes.Nop;
                            Write($"{invoke} : {result}", TypeMessage.Done);
                        }
                        if (method.Body.Instructions[i].OpCode == OpCodes.Call && method.Body.Instructions[i].Operand.ToString().Contains("System.Math::") && method.Body.Instructions[i].Operand.ToString().Contains("(System.Int32,System.Int32)") && method.Body.Instructions[i - 1].OpCode == OpCodes.Ldc_I4 && method.Body.Instructions[i - 2].OpCode == OpCodes.Ldc_I4)
                        {
                            MemberRef memberRef = (MemberRef)method.Body.Instructions[i].Operand;
                            MethodBase invoke = typeof(System.Math).GetMethod(memberRef.Name, new System.Type[] { typeof(int), typeof(int) });
                            int arg1 = (int)method.Body.Instructions[i - 1].Operand; 
                            int arg2 = (int)method.Body.Instructions[i - 2].Operand;
                            int result = (int)invoke.Invoke(null, new object[] { arg1, arg2 });
                            method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
                            method.Body.Instructions[i].Operand = result;
                            method.Body.Instructions[i - 1].OpCode = OpCodes.Nop;
                            method.Body.Instructions[i - 2].OpCode = OpCodes.Nop;
                            Write($"{invoke} : {result}", TypeMessage.Done);
                        }
                    }
                }
            }
        }
    }
}
