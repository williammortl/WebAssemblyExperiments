fn main() {
    hello_world();
}

#[no_mangle]
pub extern "C" fn hello_world() {
    println!("Hello, world!");
}
