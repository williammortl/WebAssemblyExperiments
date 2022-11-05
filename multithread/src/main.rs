use std::thread;
use text_io::read;

// https://github.com/bytecodealliance/wasmtime/blob/main/examples/threads.rs

fn main() {
    for i in 1..10 {
        thread::spawn(move || {
            for j in 1..20 {
                println!("thread: {}, number: {}", i, j);
            }
        });
    }

    // wait for input
    let _line: String = read!("{}\n");
}
