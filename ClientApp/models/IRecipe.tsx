import * as React from 'react';
import { ITag, IIngredient } from './index';

export interface IRecipe {
  name: string,
  description: string,
  preparation: string,
  drinkware: string,
  service: string,
  ingredients: Array<IIngredient>,
  garnishes: Array<IIngredient>,
  tags: Array<ITag>,
  imageUrl: string,
  photoCred: string,
}