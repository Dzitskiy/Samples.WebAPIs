export type Maybe<T> = T | null;
export type Exact<T extends { [key: string]: unknown }> = { [K in keyof T]: T[K] };
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: string;
  String: string;
  Boolean: boolean;
  Int: number;
  Float: number;
  /** The multiplier path scalar represents a valid GraphQL multiplier path string. */
  MultiplierPath: any;
  PaginationAmount: any;
  /** The `DateTime` scalar represents an ISO-8601 compliant date time type. */
  DateTime: any;
};


export type WeatherQueries = {
  __typename?: 'WeatherQueries';
  weatherForecast?: Maybe<WeatherForecastConnection>;
};


export type WeatherQueriesWeatherForecastArgs = {
  after?: Maybe<Scalars['String']>;
  before?: Maybe<Scalars['String']>;
  first?: Maybe<Scalars['PaginationAmount']>;
  last?: Maybe<Scalars['PaginationAmount']>;
  order_by?: Maybe<WeatherForecastSort>;
  where?: Maybe<WeatherForecastFilter>;
};

export type WeatherForecast = {
  __typename?: 'WeatherForecast';
  forecastDate: Scalars['DateTime'];
  summary: Scalars['String'];
  temperatureC: Scalars['Int'];
  temperatureF: Scalars['Int'];
};

export type WeatherForecastFilter = {
  AND?: Maybe<Array<WeatherForecastFilter>>;
  forecastDate?: Maybe<Scalars['DateTime']>;
  forecastDate_gt?: Maybe<Scalars['DateTime']>;
  forecastDate_gte?: Maybe<Scalars['DateTime']>;
  forecastDate_in?: Maybe<Array<Scalars['DateTime']>>;
  forecastDate_lt?: Maybe<Scalars['DateTime']>;
  forecastDate_lte?: Maybe<Scalars['DateTime']>;
  forecastDate_not?: Maybe<Scalars['DateTime']>;
  forecastDate_not_gt?: Maybe<Scalars['DateTime']>;
  forecastDate_not_gte?: Maybe<Scalars['DateTime']>;
  forecastDate_not_in?: Maybe<Array<Scalars['DateTime']>>;
  forecastDate_not_lt?: Maybe<Scalars['DateTime']>;
  forecastDate_not_lte?: Maybe<Scalars['DateTime']>;
  OR?: Maybe<Array<WeatherForecastFilter>>;
  summary?: Maybe<Scalars['String']>;
  summary_contains?: Maybe<Scalars['String']>;
  summary_ends_with?: Maybe<Scalars['String']>;
  summary_in?: Maybe<Array<Scalars['String']>>;
  summary_not?: Maybe<Scalars['String']>;
  summary_not_contains?: Maybe<Scalars['String']>;
  summary_not_ends_with?: Maybe<Scalars['String']>;
  summary_not_in?: Maybe<Array<Scalars['String']>>;
  summary_not_starts_with?: Maybe<Scalars['String']>;
  summary_starts_with?: Maybe<Scalars['String']>;
  temperatureC?: Maybe<Scalars['Int']>;
  temperatureC_gt?: Maybe<Scalars['Int']>;
  temperatureC_gte?: Maybe<Scalars['Int']>;
  temperatureC_in?: Maybe<Array<Scalars['Int']>>;
  temperatureC_lt?: Maybe<Scalars['Int']>;
  temperatureC_lte?: Maybe<Scalars['Int']>;
  temperatureC_not?: Maybe<Scalars['Int']>;
  temperatureC_not_gt?: Maybe<Scalars['Int']>;
  temperatureC_not_gte?: Maybe<Scalars['Int']>;
  temperatureC_not_in?: Maybe<Array<Scalars['Int']>>;
  temperatureC_not_lt?: Maybe<Scalars['Int']>;
  temperatureC_not_lte?: Maybe<Scalars['Int']>;
  temperatureF?: Maybe<Scalars['Int']>;
  temperatureF_gt?: Maybe<Scalars['Int']>;
  temperatureF_gte?: Maybe<Scalars['Int']>;
  temperatureF_in?: Maybe<Array<Scalars['Int']>>;
  temperatureF_lt?: Maybe<Scalars['Int']>;
  temperatureF_lte?: Maybe<Scalars['Int']>;
  temperatureF_not?: Maybe<Scalars['Int']>;
  temperatureF_not_gt?: Maybe<Scalars['Int']>;
  temperatureF_not_gte?: Maybe<Scalars['Int']>;
  temperatureF_not_in?: Maybe<Array<Scalars['Int']>>;
  temperatureF_not_lt?: Maybe<Scalars['Int']>;
  temperatureF_not_lte?: Maybe<Scalars['Int']>;
};

export type WeatherForecastSort = {
  forecastDate?: Maybe<SortOperationKind>;
  summary?: Maybe<SortOperationKind>;
  temperatureC?: Maybe<SortOperationKind>;
  temperatureF?: Maybe<SortOperationKind>;
};

/** A connection to a list of items. */
export type WeatherForecastConnection = {
  __typename?: 'WeatherForecastConnection';
  /** A list of edges. */
  edges?: Maybe<Array<WeatherForecastEdge>>;
  /** A flattened list of the nodes. */
  nodes?: Maybe<Array<Maybe<WeatherForecast>>>;
  /** Information to aid in pagination. */
  pageInfo: PageInfo;
  totalCount: Scalars['Int'];
};


export enum SortOperationKind {
  Asc = 'ASC',
  Desc = 'DESC'
}

/** Information about pagination in a connection. */
export type PageInfo = {
  __typename?: 'PageInfo';
  /** When paginating forwards, the cursor to continue. */
  endCursor?: Maybe<Scalars['String']>;
  /** Indicates whether more edges exist following the set defined by the clients arguments. */
  hasNextPage: Scalars['Boolean'];
  /** Indicates whether more edges exist prior the set defined by the clients arguments. */
  hasPreviousPage: Scalars['Boolean'];
  /** When paginating backwards, the cursor to continue. */
  startCursor?: Maybe<Scalars['String']>;
};

/** An edge in a connection. */
export type WeatherForecastEdge = {
  __typename?: 'WeatherForecastEdge';
  /** A cursor for use in pagination. */
  cursor: Scalars['String'];
  /** The item at the end of the edge. */
  node?: Maybe<WeatherForecast>;
};


export type GetWeatherForecastsQueryVariables = Exact<{
  first?: Maybe<Scalars['PaginationAmount']>;
}>;


export type GetWeatherForecastsQuery = (
  { __typename?: 'WeatherQueries' }
  & { weatherForecast?: Maybe<(
    { __typename?: 'WeatherForecastConnection' }
    & { nodes?: Maybe<Array<Maybe<(
      { __typename?: 'WeatherForecast' }
      & Pick<WeatherForecast, 'summary' | 'temperatureC' | 'temperatureF'>
    )>>> }
  )> }
);
