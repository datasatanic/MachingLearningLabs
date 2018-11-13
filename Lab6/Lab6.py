import sys
from Classes import *
input=np.array([
    [1,-1,1,-1,1,-1,1,-1,1],
    [-1,1,-1,1,1,1,-1,1,-1],
    [1,1,1,1,-1,1,1,1,1]])

vect=np.array([1,-1,-1,-1,1,-1,1,-1,1])

def main():
    net=Hemming(input,0.3)
    print(net.compute(vect))

if __name__ == "__main__":
    sys.exit(int(main() or 0))
