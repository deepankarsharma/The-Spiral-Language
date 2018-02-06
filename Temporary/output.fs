module SpiralExample.Main
let cuda_kernels = """
#include "cub/cub.cuh"

extern "C" {
    __global__ void method_7(long long int * var_0, long long int * var_1);
    __device__ char method_8(long long int * var_0, long long int * var_1);
    
    __global__ void method_7(long long int * var_0, long long int * var_1) {
        long long int var_2 = threadIdx.x;
        long long int var_3 = blockIdx.x;
        long long int var_4 = (32 * var_3);
        long long int var_5 = (var_2 + var_4);
        long long int var_6 = 0;
        long long int var_7[1];
        long long int var_8[1];
        var_7[0] = var_5;
        var_8[0] = var_6;
        while (method_8(var_7, var_8)) {
            long long int var_10 = var_7[0];
            long long int var_11 = var_8[0];
            char var_12 = (var_10 >= 0);
            char var_14;
            if (var_12) {
                var_14 = (var_10 < 32);
            } else {
                var_14 = 0;
            }
            char var_15 = (var_14 == 0);
            if (var_15) {
                // "Argument out of bounds."
            } else {
            }
            long long int var_16 = var_0[var_10];
            long long int var_17 = (var_11 + var_16);
            long long int var_18 = (var_10 + 32);
            var_7[0] = var_18;
            var_8[0] = var_17;
        }
        long long int var_19 = var_7[0];
        long long int var_20 = var_8[0];
        long long int var_21 = cub::BlockReduce<long long int,32,cub::BLOCK_REDUCE_WARP_REDUCTIONS,1,1>().Sum(var_20);
        long long int var_22 = threadIdx.x;
        char var_23 = (var_22 == 0);
        if (var_23) {
            long long int var_24 = blockIdx.x;
            char var_25 = (var_24 >= 0);
            char var_27;
            if (var_25) {
                var_27 = (var_24 < 1);
            } else {
                var_27 = 0;
            }
            char var_28 = (var_27 == 0);
            if (var_28) {
                // "Argument out of bounds."
            } else {
            }
            var_1[var_24] = var_21;
        } else {
        }
    }
    __device__ char method_8(long long int * var_0, long long int * var_1) {
        long long int var_2 = var_0[0];
        long long int var_3 = var_1[0];
        return (var_2 < 32);
    }
}
"""

type EnvStack0 =
    struct
    val mem_0: (uint64 ref)
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
and Env1 =
    struct
    val mem_0: EnvStack0
    val mem_1: uint64
    new(arg_mem_0, arg_mem_1) = {mem_0 = arg_mem_0; mem_1 = arg_mem_1}
    end
and EnvStack2 =
    struct
    val mem_0: EnvStack0
    new(arg_mem_0) = {mem_0 = arg_mem_0}
    end
let rec method_0 ((var_0: System.Diagnostics.DataReceivedEventArgs)): unit =
    let (var_1: string) = var_0.get_Data()
    let (var_2: string) = System.String.Format("{0}",var_1)
    System.Console.WriteLine(var_2)
and method_1((var_0: (uint64 ref))): uint64 =
    let (var_1: uint64) = (!var_0)
    let (var_2: bool) = (var_1 <> 0UL)
    let (var_3: bool) = (var_2 = false)
    if var_3 then
        (failwith "A Cuda memory cell that has been disposed has been tried to be accessed.")
    else
        ()
    var_1
and method_2((var_0: (int64 [])), (var_1: int64)): unit =
    let (var_2: bool) = (var_1 < 32L)
    if var_2 then
        let (var_3: bool) = (var_1 >= 0L)
        let (var_4: bool) = (var_3 = false)
        if var_4 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_5: int64) = (1L + var_1)
        var_0.[int32 var_1] <- var_5
        let (var_6: int64) = (var_1 + 1L)
        method_2((var_0: (int64 [])), (var_6: int64))
    else
        ()
and method_3((var_0: uint64), (var_1: uint64), (var_2: System.Collections.Generic.Stack<Env1>), (var_3: int64), (var_4: (int64 [])), (var_5: int64), (var_6: int64)): EnvStack2 =
    let (var_7: int64) = (var_3 * var_6)
    let (var_8: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_4,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_9: int64) = var_8.AddrOfPinnedObject().ToInt64()
    let (var_10: uint64) = (uint64 var_9)
    let (var_11: int64) = (var_5 * 8L)
    let (var_12: uint64) = (uint64 var_11)
    let (var_13: uint64) = (var_12 + var_10)
    let (var_14: int64) = (var_7 * 8L)
    let (var_15: uint64) = (uint64 var_14)
    let (var_16: uint64) = (var_15 % 256UL)
    let (var_17: uint64) = (var_15 - var_16)
    let (var_18: uint64) = (var_17 + 256UL)
    let (var_19: EnvStack0) = method_4((var_0: uint64), (var_2: System.Collections.Generic.Stack<Env1>), (var_1: uint64), (var_18: uint64))
    let (var_20: EnvStack2) = EnvStack2((var_19: EnvStack0))
    let (var_21: EnvStack0) = var_20.mem_0
    let (var_22: (uint64 ref)) = var_21.mem_0
    let (var_23: uint64) = method_1((var_22: (uint64 ref)))
    let (var_24: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_23)
    let (var_25: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_24)
    let (var_26: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_13)
    let (var_27: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_26)
    let (var_28: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_29: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_25, var_27, var_28)
    if var_29 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_29)
    var_8.Free()
    var_20
and method_4((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env1>), (var_2: uint64), (var_3: uint64)): EnvStack0 =
    let (var_4: int32) = var_1.get_Count()
    let (var_5: bool) = (var_4 > 0)
    if var_5 then
        let (var_6: Env1) = var_1.Peek()
        let (var_7: EnvStack0) = var_6.mem_0
        let (var_8: uint64) = var_6.mem_1
        let (var_9: (uint64 ref)) = var_7.mem_0
        let (var_10: uint64) = (!var_9)
        let (var_11: bool) = (var_10 = 0UL)
        if var_11 then
            let (var_12: Env1) = var_1.Pop()
            let (var_13: EnvStack0) = var_12.mem_0
            let (var_14: uint64) = var_12.mem_1
            method_4((var_0: uint64), (var_1: System.Collections.Generic.Stack<Env1>), (var_2: uint64), (var_3: uint64))
        else
            method_5((var_10: uint64), (var_0: uint64), (var_2: uint64), (var_3: uint64), (var_1: System.Collections.Generic.Stack<Env1>), (var_8: uint64))
    else
        method_6((var_0: uint64), (var_2: uint64), (var_3: uint64), (var_1: System.Collections.Generic.Stack<Env1>))
and method_9((var_0: int64), (var_1: EnvStack2), (var_2: int64), (var_3: int64)): (int64 []) =
    let (var_4: EnvStack0) = var_1.mem_0
    let (var_5: int64) = (var_0 * var_3)
    let (var_6: (uint64 ref)) = var_4.mem_0
    let (var_7: uint64) = method_1((var_6: (uint64 ref)))
    let (var_8: int64) = (var_2 * 8L)
    let (var_9: uint64) = (uint64 var_8)
    let (var_10: uint64) = (var_7 + var_9)
    let (var_11: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(var_5))
    let (var_12: System.Runtime.InteropServices.GCHandle) = System.Runtime.InteropServices.GCHandle.Alloc(var_11,System.Runtime.InteropServices.GCHandleType.Pinned)
    let (var_13: int64) = var_12.AddrOfPinnedObject().ToInt64()
    let (var_14: uint64) = (uint64 var_13)
    let (var_15: int64) = (var_5 * 8L)
    let (var_16: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_14)
    let (var_17: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_16)
    let (var_18: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_10)
    let (var_19: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_18)
    let (var_20: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_15)
    let (var_21: ManagedCuda.BasicTypes.CUResult) = ManagedCuda.DriverAPINativeMethods.SynchronousMemcpy_v2.cuMemcpy(var_17, var_19, var_20)
    if var_21 <> ManagedCuda.BasicTypes.CUResult.Success then raise <| new ManagedCuda.CudaException(var_21)
    var_12.Free()
    var_11
and method_10((var_0: (int64 [])), (var_1: int64), (var_2: int64)): int64 =
    let (var_3: bool) = (var_2 < 1L)
    if var_3 then
        let (var_4: bool) = (var_2 >= 0L)
        let (var_5: bool) = (var_4 = false)
        if var_5 then
            (failwith "Argument out of bounds.")
        else
            ()
        let (var_6: int64) = var_0.[int32 var_2]
        let (var_7: int64) = (var_1 + var_6)
        let (var_8: int64) = (var_2 + 1L)
        method_10((var_0: (int64 [])), (var_7: int64), (var_8: int64))
    else
        var_1
and method_5((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: uint64), (var_4: System.Collections.Generic.Stack<Env1>), (var_5: uint64)): EnvStack0 =
    let (var_6: uint64) = (var_0 + var_5)
    let (var_7: uint64) = (var_1 + var_2)
    let (var_8: uint64) = (var_7 - var_6)
    let (var_9: bool) = (var_3 <= var_8)
    let (var_10: bool) = (var_9 = false)
    if var_10 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_11: (uint64 ref)) = (ref var_6)
    let (var_12: EnvStack0) = EnvStack0((var_11: (uint64 ref)))
    var_4.Push((Env1(var_12, var_3)))
    var_12
and method_6((var_0: uint64), (var_1: uint64), (var_2: uint64), (var_3: System.Collections.Generic.Stack<Env1>)): EnvStack0 =
    let (var_4: uint64) = (var_0 + var_1)
    let (var_5: uint64) = (var_4 - var_0)
    let (var_6: bool) = (var_2 <= var_5)
    let (var_7: bool) = (var_6 = false)
    if var_7 then
        (failwith "Cache size has been exceeded in the allocator.")
    else
        ()
    let (var_8: (uint64 ref)) = (ref var_0)
    let (var_9: EnvStack0) = EnvStack0((var_8: (uint64 ref)))
    var_3.Push((Env1(var_9, var_2)))
    var_9
let (var_0: string) = cuda_kernels
let (var_1: ManagedCuda.CudaContext) = ManagedCuda.CudaContext(false)
var_1.Synchronize()
let (var_2: string) = System.Environment.get_CurrentDirectory()
let (var_3: string) = System.IO.Path.Combine(var_2, "nvcc_router.bat")
let (var_4: System.Diagnostics.ProcessStartInfo) = System.Diagnostics.ProcessStartInfo()
var_4.set_RedirectStandardOutput(true)
var_4.set_RedirectStandardError(true)
var_4.set_UseShellExecute(false)
var_4.set_FileName(var_3)
let (var_5: System.Diagnostics.Process) = System.Diagnostics.Process()
var_5.set_StartInfo(var_4)
let (var_7: (System.Diagnostics.DataReceivedEventArgs -> unit)) = method_0
var_5.OutputDataReceived.Add(var_7)
var_5.ErrorDataReceived.Add(var_7)
let (var_8: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Auxiliary/Build/vcvars64.bat")
let (var_9: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/bin/Hostx64/x64")
let (var_10: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "include")
let (var_11: string) = System.IO.Path.Combine("C:/Program Files (x86)/Microsoft Visual Studio/2017/Community", "VC/Tools/MSVC/14.11.25503/include")
let (var_12: string) = System.IO.Path.Combine("C:/Program Files/NVIDIA GPU Computing Toolkit/CUDA/v9.0", "bin/nvcc.exe")
let (var_13: string) = System.IO.Path.Combine(var_2, "cuda_kernels.ptx")
let (var_14: string) = System.IO.Path.Combine(var_2, "cuda_kernels.cu")
let (var_15: bool) = System.IO.File.Exists(var_14)
if var_15 then
    System.IO.File.Delete(var_14)
else
    ()
System.IO.File.WriteAllText(var_14, var_0)
let (var_16: bool) = System.IO.File.Exists(var_3)
if var_16 then
    System.IO.File.Delete(var_3)
else
    ()
let (var_17: System.IO.FileStream) = System.IO.File.OpenWrite(var_3)
let (var_18: System.IO.StreamWriter) = System.IO.StreamWriter(var_17)
var_18.WriteLine("SETLOCAL")
let (var_19: string) = String.concat "" [|"CALL "; "\""; var_8; "\""|]
var_18.WriteLine(var_19)
let (var_20: string) = String.concat "" [|"SET PATH=%PATH%;"; "\""; var_9; "\""|]
var_18.WriteLine(var_20)
let (var_21: string) = String.concat "" [|"\""; var_12; "\" -gencode=arch=compute_52,code=\\\"sm_52,compute_52\\\" --use-local-env --cl-version 2017 -I\""; var_10; "\" -I\"C:/cub-1.7.4\" -I\""; var_11; "\" --keep-dir \""; var_2; "\" -maxrregcount=0  --machine 64 -ptx -cudart static  -o \""; var_13; "\" \""; var_14; "\""|]
var_18.WriteLine(var_21)
var_18.Dispose()
var_17.Dispose()
let (var_22: System.Diagnostics.Stopwatch) = System.Diagnostics.Stopwatch.StartNew()
let (var_23: bool) = var_5.Start()
let (var_24: bool) = (var_23 = false)
if var_24 then
    (failwith "NVCC failed to run.")
else
    ()
var_5.BeginOutputReadLine()
var_5.BeginErrorReadLine()
var_5.WaitForExit()
let (var_25: int32) = var_5.get_ExitCode()
let (var_26: bool) = (var_25 = 0)
let (var_27: bool) = (var_26 = false)
if var_27 then
    let (var_28: string) = System.String.Format("{0}",var_25)
    let (var_29: string) = String.concat ", " [|"NVCC failed compilation."; var_28|]
    let (var_30: string) = System.String.Format("[{0}]",var_29)
    (failwith var_30)
else
    ()
let (var_31: System.TimeSpan) = var_22.get_Elapsed()
printfn "The time it took to compile the Cuda kernels is: %A" var_31
let (var_32: ManagedCuda.BasicTypes.CUmodule) = var_1.LoadModulePTX(var_13)
var_5.Dispose()
let (var_33: string) = String.concat "" [|"Compiled the kernels into the following directory: "; var_2|]
let (var_34: string) = System.String.Format("{0}",var_33)
System.Console.WriteLine(var_34)
let (var_35: ManagedCuda.BasicTypes.SizeT) = var_1.GetFreeDeviceMemorySize()
let (var_36: int64) = int64 var_35
let (var_37: float) = float var_36
let (var_38: float) = (0.700000 * var_37)
let (var_39: uint64) = uint64 var_38
let (var_40: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_39)
let (var_41: ManagedCuda.BasicTypes.CUdeviceptr) = var_1.AllocateMemory(var_40)
let (var_42: uint64) = uint64 var_41
let (var_43: (uint64 ref)) = (ref var_42)
let (var_44: EnvStack0) = EnvStack0((var_43: (uint64 ref)))
let (var_45: System.Collections.Generic.Stack<Env1>) = System.Collections.Generic.Stack<Env1>()
let (var_46: (uint64 ref)) = var_44.mem_0
let (var_47: uint64) = method_1((var_46: (uint64 ref)))
let (var_48: ManagedCuda.CudaStream) = ManagedCuda.CudaStream()
let (var_49: (int64 [])) = Array.zeroCreate<int64> (System.Convert.ToInt32(32L))
let (var_50: int64) = 0L
method_2((var_49: (int64 [])), (var_50: int64))
let (var_51: int64) = 32L
let (var_52: int64) = 0L
let (var_53: int64) = 1L
let (var_54: EnvStack2) = method_3((var_47: uint64), (var_39: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_51: int64), (var_49: (int64 [])), (var_52: int64), (var_53: int64))
let (var_55: EnvStack0) = var_54.mem_0
let (var_56: (uint64 ref)) = var_55.mem_0
let (var_57: uint64) = method_1((var_56: (uint64 ref)))
let (var_58: uint64) = 256UL
let (var_59: EnvStack0) = method_4((var_47: uint64), (var_45: System.Collections.Generic.Stack<Env1>), (var_39: uint64), (var_58: uint64))
let (var_60: EnvStack2) = EnvStack2((var_59: EnvStack0))
let (var_61: EnvStack0) = var_60.mem_0
let (var_62: (uint64 ref)) = var_61.mem_0
let (var_63: uint64) = method_1((var_62: (uint64 ref)))
// Cuda join point
// method_7((var_57: uint64), (var_63: uint64))
let (var_64: ManagedCuda.CudaKernel) = ManagedCuda.CudaKernel("method_7", var_32, var_1)
let (var_65: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(1u, 1u, 1u)
var_64.set_GridDimensions(var_65)
let (var_66: ManagedCuda.VectorTypes.dim3) = ManagedCuda.VectorTypes.dim3(32u, 1u, 1u)
var_64.set_BlockDimensions(var_66)
let (var_67: ManagedCuda.BasicTypes.CUstream) = var_48.get_Stream()
let (var_69: (System.Object [])) = [|var_57; var_63|]: (System.Object [])
var_64.RunAsync(var_67, var_69)
let (var_70: int64) = 1L
let (var_71: int64) = 0L
let (var_72: int64) = 1L
let (var_73: (int64 [])) = method_9((var_70: int64), (var_60: EnvStack2), (var_71: int64), (var_72: int64))
let (var_74: int64) = var_73.[int32 0L]
let (var_75: int64) = 1L
let (var_76: int64) = method_10((var_73: (int64 [])), (var_74: int64), (var_75: int64))
var_62 := 0UL
let (var_77: string) = System.String.Format("{0}",var_76)
System.Console.WriteLine(var_77)
var_56 := 0UL
var_48.Dispose()
let (var_78: uint64) = method_1((var_46: (uint64 ref)))
let (var_79: ManagedCuda.BasicTypes.SizeT) = ManagedCuda.BasicTypes.SizeT(var_78)
let (var_80: ManagedCuda.BasicTypes.CUdeviceptr) = ManagedCuda.BasicTypes.CUdeviceptr(var_79)
var_1.FreeMemory(var_80)
var_46 := 0UL
var_1.Dispose()

