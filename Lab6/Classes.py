import numpy as np

class Hemming:
    def __init__(self,input,eps=-1,norm=0.1):
        self.Input=input
        self.T=len(input[0])/2
        self.eps=1/len(input)if eps==-1 else eps
        self.norm=norm
        self.W=input/2
        self.V=np.identity(len(input))-self.eps+np.identity(len(input))*self.eps

    def func(self,vect):
        for i in range(len(vect)):
            if(vect[i]<=0):
                vect[i]=0
            elif(vect[i]>=self.T):
                vect[i]=self.T
        return vect

    def res(self,vect):
        if np.count_nonzero(vect)>1 or np.count_nonzero(vect)==0:
            return "Класс не распознан"
        else:
            return "Объект принадлежит классу %d"%(np.flatnonzero(vect)[0]+1)
                
    def compute(self,vect):
        y1=self.func(np.dot(self.W,vect)+self.T)
        y2=self.func(np.dot(self.V,y1))
        while np.linalg.norm(y2-y1)>self.norm:
            y1=y2
            y2=self.func(np.dot(self.V,y1))
        return self.res(y2)
        
