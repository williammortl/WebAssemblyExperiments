all: clean build

build: src/main.rs
	cargo +nightly build

clean:
	rm -rf target

run:
	wasmtime target/wasm32-wasi/debug/multithread.wasm