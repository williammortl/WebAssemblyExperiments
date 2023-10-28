// See https://aka.ms/new-console-template for more information
using Wasmtime;

var wasi = new WasiConfiguration()
    .WithInheritedStandardInput()
    .WithInheritedStandardOutput()
    .WithInheritedStandardError()
    .WithArg("--wasi threads");
var config = new Config()
    .WithWasmThreads(true)
    .WithBulkMemory(true)
    .WithMultiMemory(true);
using var engine = new Engine(config);
using var store = new Store(engine);
store.SetWasiConfiguration(wasi);
using var linker = new Linker(engine);
linker.DefineWasi();

/*
using var module = Module.FromText(
    engine,
    "hello",
    "(module (func $hello (import \"\" \"hello\")) (func (export \"run\") (call $hello)))"
);
*/

// using var module = Module.FromFile(engine, "hello-world.wasm");
using var module = Module.FromFile(engine, "threads.wasm");

/*
linker.Define(
    "",
    "hello",
    Function.FromCallback(store, () => Console.WriteLine("Hello from C#!"))
);
*/


var instance = linker.Instantiate(store, module);
var run = instance.GetFunction("_start").Invoke();
