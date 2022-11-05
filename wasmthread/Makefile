all: clean build build-wasm

build: src/main.rs
	cargo +nightly build --target wasm32-wasi

clean:
	rm -rf target

run:
	wasmtime target/wasm32-wasi/debug/multithread.wasm