import sys
from Classes import *
from datetime import datetime

def main():
    net=ConvolutionNetwork()
    net.Load()
    net.LoadData()
    net.Fit()
    net.Save()
    input("Окончание обучения: %s"%datetime.strftime(datetime.now(), "%Y.%m.%d %H:%M:%S"))#75%

if __name__ == "__main__":
    sys.exit(int(main() or 0))




