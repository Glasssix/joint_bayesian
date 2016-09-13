import numpy as np
import matplotlib.pyplot as plt
import os
import caffe
import sys
import pickle
import struct
import sys,cv2
caffe_root = 'C:/Users/machao/Desktop/lfw_train/'  
#
deployPrototxt =  'caffemodel/Reject_deploy.prototxt'
#
modelFile = 'caffemodel/Reject.caffemodel'
#meanfile
meanFile = 'meanfile/trainset4038.npy'
#
imageListFile = 'trainset4038.txt'
imageBasePath = 'C:/Users/machao/Desktop/lfw_funneled/'

dat_path='C:/Users/machao/Desktop/lfw_train/trainset4038_feature.dat'
#gpuID = 4
postfix = '.dat'

#
def initilize():
    print 'initilize ... '

    sys.path.insert(0, caffe_root + 'python')
    #caffe.set_mode_gpu()
    #caffe.set_device(gpuID)
    net = caffe.Net(deployPrototxt, modelFile,caffe.TEST)
    return net  
#
def extractFeature(imageList, net):
    #
    transformer = caffe.io.Transformer({'data': net.blobs['data'].data.shape})
    transformer.set_transpose('data', (2,0,1))
    transformer.set_mean('data', np.load(caffe_root + meanFile).mean(1).mean(1)) # mean pixel
    transformer.set_raw_scale('data', 255)  
    transformer.set_channel_swap('data', (2,1,0))  
    # set net to batch size of 1
    #net.blobs['data'].reshape(1,3,250,250)
    num=0
    f=file(dat_path,'w') 
    for imagefile in imageList:
        imagefile_abs = os.path.join(imageBasePath, imagefile)
        print imagefile_abs
        net.blobs['data'].data[...] = transformer.preprocess('data', caffe.io.load_image(imagefile_abs))
        out = net.forward()
        #fea_file = imagefile_abs.replace('.jpg',postfix)
        num +=1
        #print 'Num ',num,' extract feature ',fea_file
        for x in xrange(0, net.blobs['ip1'].data.shape[0]):
            for y in xrange(0, net.blobs['ip1'].data.shape[1]):
                #f.write(struct.pack('f', net.blobs['ip1'].data[x,y])," ")
                f.write(str(net.blobs['ip1'].data[x,y]))
                f.write(' ')
        f.write('\n')
                    #print net.blobs['ip1'].data[x,y]
    f.close()
    
def readImageList(imageListFile):
    imageList = []
    with open(imageListFile,'r') as fi:
        while(True):
            line = fi.readline().strip().split()# every line is a image file name
            if not line:
                break
            imageList.append(line[0]) 
    print 'read imageList done image num ', len(imageList)
    return imageList

if __name__ == "__main__":
    net = initilize()
    imageList = readImageList(imageListFile) 
    extractFeature(imageList, net)