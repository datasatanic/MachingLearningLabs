import numpy as np

class Hemming:
    def __init__(self,input,eps, *args, **kwargs):
        self.Input=input
        self.T=len(input[0])/2
        self.eps=eps
        self.W=input/2
        self.V=np.identity(len(input))-self.eps+np.identity(len(input))*self.eps

    def func(self,vect):
        for i in vect:
            if(i<=0):
                i=0
            elif(i>=T):
                i=T
        return vect
                
    def compute(self,vect):
        y1=self.func(np.dot(self.W,vect)+self.T)
        y2=self.func(np.dot(self.V,y1))
        while np.linalg.norm(y1,y2)>self.eps:
            y1=y2
            y2=self.func(np.dot(self.V,y1))
        
