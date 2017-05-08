#include <stdlib.h>
#include <math.h>
#include "LowLevelPlugin.hpp"
#include <fstream>

/**
    適当にログ書き出す
 */
void writeLog (std::string message) {
    std::ofstream outfile;
    bool isOpen = outfile.is_open();
    if (!isOpen) {
        outfile.open("debug.log", std::ios_base::app);
    }
    
    outfile << message+"\n";
}


/*
 
 */
extern "C" int ** EXPORT_API fillArray(int size) {
    writeLog("message!");
    writeLog("message!2");
    writeLog("message!3");
    writeLog("message!4");
    
    
    int i = 0, j = 0;
    int ** array = (int**) calloc(size, sizeof(int*));
    for(i = 0; i < size; i++) {
        array[i] = (int*) calloc(size, sizeof(int));
        for(j = 0; j < size; j++) {
            array[i][j] = i * size + j;
        }
    }
    
    // 値を返せるっぽい
    return array;
}
