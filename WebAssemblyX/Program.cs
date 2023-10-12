// See https://aka.ms/new-console-template for more information
using Wasmtime;

var config = new Config();
config.WithWasmThreads(true);
using var engine = new Engine(config);

/*
using var module = Module.FromText(
    engine,
    "hello",
    "(module (func $hello (import \"\" \"hello\")) (func (export \"run\") (call $hello)))"
);
*/

using var module = Module.FromText(
    engine,
    "hello",
    "(module (func $hello (import \"\" \"hello\")) (func (export \"run\") (call $hello)))"
);

using var linker = new Linker(engine);
using var store = new Store(engine);


linker.Define(
    "",
    "hello",
    Function.FromCallback(store, () => Console.WriteLine("Hello from C#!"))
);


var instance = linker.Instantiate(store, module);
var run = instance.GetAction("run")!;
run();
