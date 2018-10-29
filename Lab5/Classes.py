from numpy import *

class Hopfield:
    """Сеть Хопфилда"""
    def __init__(self,input):
        self.input=input
        self.Weight=self.__GetWeigtMatrix(input)    

    def __GetWeigtMatrix(cls,train):
        '''Получение матрицы весов'''
        W=zeros((len(train[0]),len(train[0])))
        for tr in train:
            V2=matrix(tr)
            V1=transpose(V2)
            W+=dot(V1,V2)
        W-=diag(diag(W))
        return W   

    def __FormatString(self,x):
        '''Форматированная строка'''
        n=round(sqrt(len(x)))
        S="["
        for i in range(len(x)):
            if(i%n==0 and i!=0):
                S+="\n  "
            S+=" {0:2}".format(1 if x[i]>0 else 0)
        return S+"]"

    def __Equal(self,x):
        Max=0
        ind=-1
        for i in range(len(self.input)):
            res=equal(x,self.input[i])
            T=0
            F=0
            for b in res:
                if b:
                    T+=1                
            if Max<T/len(res):
                Max=T/len(res)
                ind=i
        return (ind,Max)

    def GetClass(self,check):
        '''Получить класс'''
        y=transpose(matrix(check))
        y1=sign(dot(self.Weight,y))
        y2=sign(dot(self.Weight,y1))
        while not(y1==y2).all():
            y1=y2
            y2=sign(dot(self.Weight,y1))
        res=tuple(map(lambda x: x.tolist()[0][0],y2)) 
        ind,max=self.__Equal(res)      
        print("Элемент\n {0} \n принадлежит классу\n {1}\n c индексом={2} c вероятностью {3:.2%}\n".format(self.__FormatString(check),self.__FormatString(self.input[ind]),ind,max))


