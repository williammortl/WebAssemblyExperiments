all: clean build-x86 build-wasm

build-x86: src/main.rs
	cargo build

build-wasm: src/main.rs
	cargo build --target wasm32-wasi

clean:
	rm -rf target

run-wasm:
	RUST_BACKTRACE=1 WASMTIME_BACKTRACE_DETAILS=1 wasmtime target/wasm32-wasi/debug/multithread.wasm

run-x86:
	./target/debug/multithread