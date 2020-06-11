import { IProduct } from './product';

// remember to use export!
export interface IPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IProduct[];
}
