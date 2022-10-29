all: clean build

build: src/main.rs
	cargo build --target wasm32-wasi

clean:
	rm -rf target

run:
	wasmtime target/wasm32-wasi/debug/hello-world.wasm