from Classes import *
import numpy as np
import matplotlib.pyplot as pl 
import imageio


def main():
    arrow=imageio.imread("arrow.bmp")
    prarrow=imageio.imread("pressed_arrow.bmp")
    input={tuple(1 if i>0 else -1 for i in arrow.ravel()):tuple(1 if i>0 else -1 for i in prarrow.ravel())}
    ass=Associative(input)
    fig1,axes=pl.subplots(1,2) 
    res,img=ass.Compute(np.array(list(input.values())[0]))
    axes[0].imshow(res.reshape(32,32))
    axes[1].imshow(img.reshape(16,16))
    src,check=Generate(input,AdditiveNoize,4)
    fig,axes=pl.subplots(2,4) 
    for i in range(4):
        axes[0,i].imshow(check[i].reshape(16,16))
        axes[1,i].imshow(ass.Compute(check[i])[1].reshape(16,16))
    pl.show()


if __name__=="__main__":
    main()
