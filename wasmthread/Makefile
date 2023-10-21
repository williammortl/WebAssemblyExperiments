all: clean build

build: src/threads.c
	$WASI_SDK_DIR/bin/clang --sysroot $WASI_SDK_DIR/share/wasi-sysroot \
    --target=wasm32-wasi-threads -pthread \
    -Wl,--import-memory,--export-memory,--max-memory=67108864 \
    src/threads.c -o bin/threads.wasm

clean:
	rm -rf bin

run:
	wasmtime target/wasm32-wasi/debug/multithread.wasm