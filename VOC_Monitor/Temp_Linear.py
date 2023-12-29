import pandas
from sklearn import linear_model

df = pandas.read_csv("RTD_data.csv")

X = df[['Resistance']]
y = df['Temp']

#print(X)
#print('\n')
#print(y)

regr = linear_model.LinearRegression()
regr.fit(X, y)

print(regr.coef_)
print(regr.intercept_)
print('\n')

score = regr.score(X, y)
print(score)

#predicted = regr.predict([[118]])

#print(predicted)