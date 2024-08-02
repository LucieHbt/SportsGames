# -*- coding: utf-8 -*-
"""
Created on Tue Jul 16 17:02:21 2024

@author: lucie
"""

from cvzone.HandTrackingModule import HandDetector
import cv2
import socket
import time

cap = cv2.VideoCapture(0)
cap.set(3, 960)
cap.set(4, 360)

success, img = cap.read()
h, w, _ = img.shape
detector = HandDetector(detectionCon=0.8, maxHands=2)

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
serverAddressPort = ("127.0.0.1", 5052)

curr_frame = 0
prev_frame = 0
delta_time = 0

while True:
    success, img = cap.read()
    if not success:
        print("Error: Could not read frame.")
        break
    
    # Retourner l'image horizontalement
    img = cv2.flip(img, 1) 
    hands, img = detector.findHands(img)
    data = []

    if hands:
        data = []
        for hand in hands:
            lmList = hand["lmList"]
            for lm in lmList:
                data.extend([lm[0], h - lm[1], lm[2]])
        sock.sendto(str.encode(str(data)), serverAddressPort)
    
    curr_frame = time.time()
    delta_time = curr_frame - prev_frame
    prev_frame = curr_frame
    fps = int(1 / delta_time) if delta_time > 0 else 0
    cv2.putText(img, "FPS: " + str(fps), (10, 30), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)
    cv2.imshow('Hand Gesture Detection', img)

    if cv2.waitKey(5) & 0xFF == ord("q"):
        break
