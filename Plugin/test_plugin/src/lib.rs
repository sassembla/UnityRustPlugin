extern crate num;
use num::complex::Complex;
use std::io::prelude::*;
use std::fs::File;

fn find(haystack: &str, needle: char) -> Option<usize> {
    for (offset, c) in haystack.char_indices() {
        if c == needle {
            return Some(offset);
        }
    }
    None
}

fn mandelbrot(px : i32, py : i32, width : i32, height : i32) -> i32 {
    let x = (px as f32) / (width as f32) * 2.5 - 2.0;
    let y = (py as f32) / (height as f32) * 2.0 - 1.0;

    let c = Complex::new(x, y);
    let mut z = Complex::new(0.0, 0.0);
    let mut i = 0;

    while z.norm_sqr() < 4.0 {
        z = z * z + c;
        i += 1;
        if i == 300 { return 0; }
    }

    return i;
}

#[no_mangle]
pub unsafe extern fn generate_image(buffer: *mut u8, width: i32, height: i32) {
    // println!("Hello World!");// 出ない
    

    let mut f = File::create("foo.txt").unwrap();
    f.write_all(b"Hello, world!").unwrap();// できた〜〜

    // // ふーむ、なんとかしてファイルを出力したい、、、
    // let file_name = "foobar.rs";
    // match find(file_name, '.') {
    //     None => println!("No file extension found."),
    //     Some(i) => println!("File extension: {}", &file_name[i+1..]),
    // }

    // 返り値は出せないが、セットはできる。なるほど。
    let data = std::slice::from_raw_parts_mut(buffer, (width * height * 4) as usize);
    let mut offs = 0;
    for y in 0..height {
        for x in 0..width {
            let c = mandelbrot(x, y, width, height);
            data[offs + 0] = (c * 31) as u8;
            data[offs + 1] = (c * 37) as u8;
            data[offs + 2] = (c * 41) as u8;
            data[offs + 3] = 255;
            offs += 4;
        }
    }
}

#[no_mangle]
pub unsafe extern fn set_log (buffer: *mut u8) {
    let data = std::slice::from_raw_parts_mut(buffer, (5*4) as usize);
    for y in 0..5*4 {
        data[y] = 2;// 適当に文字を入れるか -> OK
    }
}

