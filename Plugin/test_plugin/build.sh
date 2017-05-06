rm -rf target/debug/deps/libtest_plugin.dylib
cargo build
cp target/debug/libtest_plugin.dylib ../../Assets/libtest_plugin.bundle