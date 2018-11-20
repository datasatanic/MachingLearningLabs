import numpy as np
from keras.datasets import cifar10
from keras.models import Sequential,load_model,model_from_json
from keras.layers import Dense,Flatten,Activation,Dropout 
from keras.layers.convolutional import Conv2D, MaxPooling2D 
from keras.utils import np_utils  
import sklearn.preprocessing as sk

class ConvolutionNetwork:
    def Create(self):
        model=Sequential()
        model.add(Conv2D(filters=32, kernel_size=(3, 3), padding='valid', input_shape=(32,32,3),activation='relu',data_format="channels_last"))
        model.add(Conv2D(filters=32, kernel_size=(3, 3), activation='relu',data_format="channels_last")) 
        model.add(MaxPooling2D(pool_size=(2,2), data_format='channels_last')) 
        model.add(Dropout(0.25))  
        model.add(Conv2D(64, (3, 3), padding='valid', activation='relu',data_format="channels_last")) 
        model.add(Conv2D(64, (3, 3), activation='relu',data_format="channels_last")) 
        model.add(MaxPooling2D(pool_size=(2,2), data_format='channels_last')) 
        model.add(Dropout(0.25)) 
        model.add(Flatten())
        model.add(Dense(512, activation='relu'))
        model.add(Dropout(0.5))  
        model.add(Dense(10, activation='softmax'))
        self.model=model

    def Compile(self):
        self.model.compile('SGD','categorical_crossentropy',['accuracy'])

    def LoadData(self):
        (x_train,y_train),(x_test,y_test)=cifar10.load_data()
        self.x_train=x_train/255
        self.x_test=x_test/255
        self.y_train=np_utils.to_categorical(y_train,10)
        self.y_test=np_utils.to_categorical(y_test,10)
    def Fit(self):
        self.model.fit(self.x_train,self.y_train,32,25,validation_split=0.1,shuffle=True)

    def Save(self):
        model_json = self.model.to_json()
        json_file = open("model.json", "w")
        json_file.write(model_json)
        json_file.close()
        self.model.save_weights("weights.h5")

    def Load(self):
        json_file = open("model.json", "r")
        loaded_model_json = json_file.read()
        json_file.close()
        self.model = model_from_json(loaded_model_json)
        self.model.load_weights("weights.h5")
        self.Compile()

    def Evaluate(self):
        scores = self.model.evaluate(self.x_test,self.y_test, verbose=0)
        print("Точность модели на тестовых данных: %.2f%%"% (scores[1]*100))



