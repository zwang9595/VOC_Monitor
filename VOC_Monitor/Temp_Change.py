import pandas
import numpy as np
from sklearn import linear_model

df = pandas.read_csv("Temp_Change.csv")

X = df[['r0']]
y1 = df['c0']
y2 = df['t0']

regr = linear_model.LinearRegression()
regr.fit(X, y1)
regr1 = linear_model.LinearRegression()
regr1.fit(X, y2)

baseline = 29

print('\n')
print('c0 coef: ', end="")
print(regr.coef_, end="")
print(', c0 intercept: ', end="")
print(regr.intercept_, end="")
score = regr.score(X, y1)
print(', c0 score: ', end="")
print(score)

print('t0 coef: ', end="")
print(regr1.coef_, end="")
print(', t0 intercept: ', end="")
print(regr1.intercept_, end="")
score2 = regr1.score(X, y2)
print(', t0 score: ', end="")
print(score2)
print('\n')

print('Prediction Table: \n')
for x in range(20, 45):
	predict = regr.predict([[x]])
	predict1 = regr1.predict([[x]])
	print(x, end = "")
	print('\t', end = "")
	print(predict, end = "")
	print('\t', end = "")
	print(predict1)

